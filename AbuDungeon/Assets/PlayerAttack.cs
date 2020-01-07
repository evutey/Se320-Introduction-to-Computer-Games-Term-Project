using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    private bool _attack;
    public Animator animator;
    public GameObject attackRange;
    
    float dtime = 0.2f;
    private float next_D = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       AttackInput();
       StopAttack();
       
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        { 
            other.transform.GetComponent<Enemy>().TakeDamage();

        }
        if (other.gameObject.CompareTag("boss"))
        { 
            other.transform.GetComponent<Enemy>().TakeDamage();

        } 
    }

    private void Attack() {
         if (_attack)
         {
            
             //if (Time.time > next_D)
             //{
                 //next_D = Time.time + dtime;
             StopAttack();
             //}
         }
     }

     private void AttackInput()
     {
         if (Input.GetKeyDown(KeyCode.LeftShift))
         {
             
             _attack = true;
             attackRange.GetComponent<CircleCollider2D>().enabled = true;
             animator.SetTrigger("attack");
         }
     }

     private void StopAttack()
     {
         _attack = false;
         attackRange.GetComponent<CircleCollider2D>().enabled = false;
        
     }
}
