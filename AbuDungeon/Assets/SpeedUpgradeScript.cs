using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgradeScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void speedUp()
    {
        if(CoinCounter.coin >=10){
        player.GetComponent<CharacterController>()
            .speed += 0.2f ;
        CoinCounter.coin -= 10;
        }
    }
}
