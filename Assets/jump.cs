using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            JumpAction();
        }
        
    }

    void JumpAction()
    {
        print("jump");
        rb.AddForce(transform.up * 500f);
        ani.SetTrigger("jump");
    }
}
