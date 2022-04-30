using UnityEngine;
using System;

public class samurai : MonoBehaviour
{
    public Animator ani;
    //private Player_Base player;
    private Rigidbody2D rigi;
    private BoxCollider2D box;
    [SerializeField] private LayerMask layer;

    void Awake()
    {
        ani = transform.GetComponent<Animator>();
        rigi = transform.GetComponent<Rigidbody2D>();
        box = transform.GetComponent<BoxCollider2D>();
        //player = gameObject.GetComponent<Player_Base>();
        //layer = transform.GetComponent<LayerMask>();
    }

    void Update()
    {
        //move right/left
        ani.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;


        //jump
        if (isGround() && Input.GetKeyDown(KeyCode.Space)){
            float jumpVelocity = 20f;
            rigi.velocity = Vector2.up * jumpVelocity;
            
        }

        HandleMovement();
        //animation
       /** if (isGround())
        {
            if(rigi.velocity.x == 0)
            {
                player.PlayIdleAnim();
            }
            else
            {
                player.PlayMoveAnim(new Vector2(rigi.velocity.x, 0f));
            }
        }
        else
        {
            player.jump(rigi.velocity);
        }*/
    }

    bool isGround()
    {
        RaycastHit2D ray = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, 1f, layer);
        //Debug.Log(ray.collider);
        return ray.collider != null;
        ani.SetTrigger("jump");
    }

    public void HandleMovement()
    {
        float moveS = 5f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigi.velocity = new Vector2(-moveS, rigi.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigi.velocity = new Vector2(+moveS, rigi.velocity.y);
            }
            else
            {
                rigi.velocity = new Vector2(0, rigi.velocity.y);
            }
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
