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

    public GameObject healthBar;

    public Animator animator;
    public Transform exit;
    public Transform bossTeleport;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    private int extraJumps;
    public int extraJumpsValue;
    
    float dtime = 0.2f;
    private float next_D = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        a1.Play();
        StartCoroutine(playSound());
        rb = GetComponent<Rigidbody2D>();
        //healthBar = healthBar.GetComponent<HealthBarScript>();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis(("Horizontal"));
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            CoinCounter.coin++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "stage2")
        {
            SceneManager.LoadScene("Stage2");
        }
        if (collision.gameObject.tag == "bonusExit")
        {
            transform.position = exit.position;
        }
        if (collision.gameObject.tag == "bossTeleport")
        {
            transform.position = bossTeleport.position;
        }
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            CoinCounter.coin++;
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            //HealthBar.health -= 50;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "spike")
        {
            if (Time.time > next_D)
            {
                next_D = Time.time + dtime;
                healthBar.GetComponent<HealthBarScript>()
                    .setHealth(healthBar.GetComponent<HealthBarScript>().getHealth() - 25);
                
            }
            if (healthBar.GetComponent<HealthBarScript>().getHealth() <= 0)
            {
                die(); 
            }
            
        }
        if (other.gameObject.tag == "enemy")
        {
            if (Time.time > next_D)
            {
                next_D = Time.time + dtime;
                healthBar.GetComponent<HealthBarScript>()
                    .setHealth(healthBar.GetComponent<HealthBarScript>().getHealth() - 30);
                
            }
            if (healthBar.GetComponent<HealthBarScript>().getHealth() <= 0)
            {
                die(); 
            }
            
        }
        if (other.gameObject.tag == "boss")
        {
            if (Time.time > next_D)
            {
                next_D = Time.time + dtime;
                healthBar.GetComponent<HealthBarScript>()
                    .setHealth(healthBar.GetComponent<HealthBarScript>().getHealth() - 50);
                
            }
            if (healthBar.GetComponent<HealthBarScript>().getHealth() <= 0)
            {
                die(); 
            }
            
        }
    }

    void die()
    {
        CoinCounter.coin = 0;
        Application.LoadLevel(Application.loadedLevel);
    }
    public void TakeDamageFromBoss(float x)
    {
        healthBar.GetComponent<HealthBarScript>()
            .setHealth(healthBar.GetComponent<HealthBarScript>().getHealth() - x);
        
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
