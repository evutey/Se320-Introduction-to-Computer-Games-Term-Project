using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 1.23f;
    public float jumpPower;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        
    }

    void Update()
    {
        float move = Input.GetAxis ("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y );
        float inputY = Input.GetAxis ("Vertical");
        
        

        if (Input.GetKey(KeyCode.Space)){
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        } 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = transform.right * speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = -transform.right * speed;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0, 0, 1) * speed;
        }
    }
}