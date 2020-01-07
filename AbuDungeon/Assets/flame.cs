using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class flame : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroybossFlame", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distance, whatIsSolid);
        if (hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Player")) {
                hitInfo.collider.GetComponent<CharacterController>().TakeDamageFromBoss(40);
            }
            DestroybossFlame();
        }


        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroybossFlame() {
        Destroy(gameObject);
    }
}