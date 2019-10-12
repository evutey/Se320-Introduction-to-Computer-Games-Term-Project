using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Vector2 moveVelocity;
    public Animator anim;
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
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
