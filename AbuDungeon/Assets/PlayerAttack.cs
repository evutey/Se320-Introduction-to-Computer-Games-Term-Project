using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    private bool attack;
    public Animator animator;
    public GameObject attackRange;
    // Start is called before the first frame update
    public GameObject mudy;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       AttackInput();
       Attack();
       StopAttack();
       
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        { 
            other.transform.GetComponent<Enemy>().takeDamage();

        } 
    }

    private void Attack() {
         if (attack)
         { 
             attackRange.SetActive(true);
             animator.SetTrigger("attack");
         }
     }

     private void AttackInput()
     {
         if (Input.GetKeyDown(KeyCode.LeftShift))
         {
             attack = true;
         }
     }

     private void StopAttack()
     {
         attack = false;
         attackRange.SetActive(false);
     }
}
