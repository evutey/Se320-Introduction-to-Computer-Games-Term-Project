using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject gObject;

    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        //anim.SetBool("isRunning", true);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("AttackRange"))
       {
           TakeDamage();
            
       }
        
   }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Destroy(gObject);
            
        }
    }

    public void TakeDamage()
    {
        health -= 50;
        Debug.Log("damage TAKEN !");
        
    }
    
}
