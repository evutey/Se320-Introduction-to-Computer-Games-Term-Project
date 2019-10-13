using UnityEngine;

public class Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1.23f;
    public float jumpPower;

    void Start()
    {
        rb.freezeRotation = true;
        
    }

    void Update()
    {
        float move = Input.GetAxis ("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y );
        float inputY = Input.GetAxis ("Vertical");
        
        rb.velocity = transform.right * speed;

            if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = -transform.right * speed;
        }
    }
}