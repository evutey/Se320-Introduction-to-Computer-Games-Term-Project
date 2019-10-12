using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class controller : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Vector2 moveVelocity;
    public Animator anim;
    public bool attack;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    { 
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        anim.SetTrigger("jump");

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        }

        HandleInput();
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        
        HandleAttacks();
        
        ResetValues();
    }

    public void HandleAttacks()
    {
       if(attack && !this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
    {
        anim.SetTrigger("attack");
        rb.velocity = Vector2.zero;
    } 
      
    }
     public void HandleInput()
           {
               if (Input.GetKeyDown(KeyCode.Z))
               {
                   attack = true;
               }
           }

     public void ResetValues()
     {
         attack = false;
     }
    
}
