using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
            //i can attack
            if (Input.GetKeyDown(KeyCode.X))
            {
                Attack();

            }
    }

    void Attack()
    {
        //play attack animation
        anim.SetTrigger("Attack");
    }
}
