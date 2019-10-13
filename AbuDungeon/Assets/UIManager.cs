using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text CoinValue;

    // Start is called before the first frame update
    void Start()
    {
        CoinValue = GetComponent<Text>();
    }
 
    // Update is called once per frame
    void Update()
    {
        Debug.Log(CoinCounter.coin.ToString());
        CoinValue.text = CoinCounter.coin.ToString();
    }
}
