using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    private TextMeshProUGUI coinAmount;
    public CoinManager coinManager;
    void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();
        coinAmount = FindObjectOfType<TextMeshProUGUI>();
    }

    public void showAmountOfCoins()
    {
        coinAmount.text = coinManager.coinAmount.ToString();
    }
    
   
}
