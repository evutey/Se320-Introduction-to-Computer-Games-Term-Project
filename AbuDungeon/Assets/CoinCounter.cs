using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public static int coin;
    public Text CoinValue;
    // Start is called before the first frame update
    void Start()
    {
        //CoinValue = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(coin.ToString());
        CoinValue.text = coin.ToString();
    }
}
