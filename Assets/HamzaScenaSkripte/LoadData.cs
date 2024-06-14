using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    public GameObject coinAmountText;
    public GameObject engineLevelText;
    public GameObject rotationSpeedText;
    void Start()
    {
        if (string.IsNullOrEmpty(PlayerPrefs.GetInt("CoinAmount").ToString()))
        {
            coinAmountText.GetComponent<TextMeshProUGUI>().text = "0";
        }
        else
        {
            coinAmountText.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("CoinAmount").ToString();
        }
      
        LoadEngineLevel();
        LoadRotationSpeed();




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadEngineLevel()
    {
        if (PlayerPrefs.GetInt("EngineLevelValue")==0)
        {
            PlayerPrefs.SetInt("EngineLevelValue", 1);
        }

        switch (PlayerPrefs.GetInt("EngineLevelValue"))
        {
            case 1 :
                engineLevelText.GetComponent<TextMeshProUGUI>().text = "Level 1";
                break;
            
            case 2 :
                engineLevelText.GetComponent<TextMeshProUGUI>().text = "Level 2";
                break;
            
            case 3 :
                engineLevelText.GetComponent<TextMeshProUGUI>().text = "Level 3";
                break;
        }
    }

    public void LoadRotationSpeed()
    {
        if (PlayerPrefs.GetInt("RotationSpeedValue")==0)
        {
            PlayerPrefs.SetInt("RotationSpeedValue", 1);
        }

        switch (PlayerPrefs.GetInt("RotationSpeedValue"))
        {
            case 1 :
                rotationSpeedText.GetComponent<TextMeshProUGUI>().text = "Level 1";
                break;
            
            case 2 :
                rotationSpeedText.GetComponent<TextMeshProUGUI>().text = "Level 2";
                break;
            
            case 3 :
                rotationSpeedText.GetComponent<TextMeshProUGUI>().text = "Level 3";
                break;
        }
    }
    
}
