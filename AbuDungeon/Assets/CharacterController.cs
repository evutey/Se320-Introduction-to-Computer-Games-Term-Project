using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;

    public float jumpForce;

    public float moveInput;

    private bool facingRight = true;

    private bool isGrounded;

    public Animator animator;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    private int extraJumps;
    public int extraJumpsValue;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis(("Horizontal"));
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0 )
            Flip();
        else if (facingRight == true && moveInput < 0)
            Flip();
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(moveInput));
        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            animator.SetBool("isJumping", true);
            extraJumps--;
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
