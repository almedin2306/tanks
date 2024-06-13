using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public GameObject canvasCoin;
    private TextMeshProUGUI coinAmount;
    public CoinManager coinManager;
    void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();
        coinAmount = canvasCoin.GetComponent<TextMeshProUGUI>();
    }

    public void showAmountOfCoins()
    {
        coinAmount.text = coinManager.coinAmount.ToString();
    }
    
   
}
