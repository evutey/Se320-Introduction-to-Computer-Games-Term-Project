using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public AudioSource a1;
    public AudioSource a2;
    
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
        a1.Play();
        StartCoroutine(playSound());
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
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            animator.SetBool("isJumping", true);
            extraJumps--;
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "spike")
        {
            die();
        }
        if (collision.gameObject.tag == "stage2")
        {
            SceneManager.LoadScene("Stage2");
        }

        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            CoinCounter.coin++;
        }
    }
    void die()
    {
        CoinCounter.coin = 0;
        Application.LoadLevel(Application.loadedLevel);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    IEnumerator playSound()
    {
        yield return new WaitForSeconds(4.728f);
        a2.Play();
       
    }

}
