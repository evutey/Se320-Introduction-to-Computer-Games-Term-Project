using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    float dtime = 1f;
    private float next_D = 0.0f;
    public Animator animator;
    public float attackRange =0.5f;
    public Transform attackPoint;
    public LayerMask playerLayer;
    public int attackDamage = 35;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next_D)
        {
            next_D = Time.time + dtime;
            bossAttack();
            animator.SetBool("isAttack", false);
        }
    }



    public void bossAttack()
    {
        animator.SetBool("isAttack", true);
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<CharacterController>().TakeDamage(attackDamage);
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
