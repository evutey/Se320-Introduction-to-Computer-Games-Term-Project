using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active : MonoBehaviour
{
    public Animator boss;
    // Start is called before the first frame update
    void Start()
    {
        boss.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            boss.SetBool("isAttack", true);
        }

    }
}
