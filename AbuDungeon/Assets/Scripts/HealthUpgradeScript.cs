using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgradeScript : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject coin;

    private int balance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void healthUp()
    {
       
        if (CoinCounter.coin >= 10){
            healthBar.GetComponent<HealthBarScript>()
                .setMaxHealth(healthBar.GetComponent<HealthBarScript>().getMaxHealth()+10);
            healthBar.GetComponent<HealthBarScript>()
                .setHealth(healthBar.GetComponent<HealthBarScript>().getHealth() + 10);
            CoinCounter.coin -= 10;
        }
    }
}
