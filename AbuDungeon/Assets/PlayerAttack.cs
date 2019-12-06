using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    private bool attack;
    public Animator animator;
    // Start is called before the first frame update
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
     private void Attack() {
         if (attack)
         { 
             animator.setTrigger("attack");
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
     }
}
