using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    public GameObject coinAmountText;
    void Start()
    {
        coinAmountText.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("CoinAmount").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
