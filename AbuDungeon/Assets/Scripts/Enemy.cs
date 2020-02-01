using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject gObject;
    
    
     public void TakeDamage(int x)
        {
            health -= x;
    
        }
     void Update()
    {
        if(health <= 0){
            Destroy(gObject);
            
        }
    }

   
    
}
