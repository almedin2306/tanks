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
    public GameObject turretRotationSpeedText;
    public GameObject healthText;
    public GameObject reloadSpeedText;

    
    void Start()
    {
        PlayerPrefs.SetInt("RotationSpeedIndex", 1);
        PlayerPrefs.SetInt("EngineLevelIndex", 1);
        PlayerPrefs.SetInt("TurretRotationSpeedIndex", 1);
        PlayerPrefs.SetInt("HealthIndex", 0);
        PlayerPrefs.SetInt("ReloadSpeedIndex", 1);
        PlayerPrefs.SetInt("CoinAmount", 2000); 
        LoadCoinAmount();
        LoadEngineLevel();
        LoadRotationSpeed();
        LoadTurretRotationSpeed();
        LoadHealth();
        LoadReloadSpeed();
       
        
        /*
        LoadFloatValues("EngineLevelIndex", "EngineLevelValue", engineLevelText, 3.0f, 6.0f, 9.0f);
        LoadFloatValues("RotationSpeedIndex", "RotationSpeedValue", rotationSpeedText, 60f, 75f, 90f);
        LoadFloatValues("TurretRotationSpeedIndex", "TurretRotationSpeedValue", turretRotationSpeedText, 35f, 55f,75f);
        LoadFloatValues("HealthIndex","HealthValue", healthText, 100, 120, 150);
        LoadFloatValues("ReloadSpeedIndex", "ReloadSpeedValue", reloadSpeedText, 3.5f, 2.2f, 1.5f);
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFloatValues(string upgradeIndex, string upgradeNameValue, GameObject textBox, float v1, float v2, float v3)
    {
        if (PlayerPrefs.GetInt(upgradeIndex)==0)
        {
            PlayerPrefs.SetInt(upgradeIndex, 1);
        }

        switch (PlayerPrefs.GetInt(upgradeIndex))
        {
            case 1 :
                textBox.GetComponent<TextMeshProUGUI>().text = "    Level 1";
                PlayerPrefs.SetFloat(upgradeNameValue,v1);
                break;
            
            case 2 :
                textBox.GetComponent<TextMeshProUGUI>().text = "    Level 2";
                PlayerPrefs.SetFloat(upgradeNameValue,v2);
                break;
            
            case 3 :
                textBox.GetComponent<TextMeshProUGUI>().text = "    Level 3";
                PlayerPrefs.SetFloat(upgradeNameValue,v3);
                break;
        }
    }


    public void LoadCoinAmount()
    {
        if (string.IsNullOrEmpty(PlayerPrefs.GetInt("CoinAmount").ToString()))
        {
            coinAmountText.GetComponent<TextMeshProUGUI>().text = "0";
        }
        else
        {
            coinAmountText.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("CoinAmount").ToString();
        }
    }
    
    public void LoadEngineLevel()
    {
        if (PlayerPrefs.GetInt("EngineLevelIndex")==0)
        {
            PlayerPrefs.SetInt("EngineLevelIndex", 1);
        }

        switch (PlayerPrefs.GetInt("EngineLevelIndex"))
        {
            case 1 :
                engineLevelText.GetComponent<TextMeshProUGUI>().text = "    Level 1";
                PlayerPrefs.SetFloat("EngineLevelValue",3.0f);
                break;
            
            case 2 :
                engineLevelText.GetComponent<TextMeshProUGUI>().text = "    Level 2";
                PlayerPrefs.SetFloat("EngineLevelValue",6.0f);
                break;
            
            case 3 :
                engineLevelText.GetComponent<TextMeshProUGUI>().text = "    Level 3";
                PlayerPrefs.SetFloat("EngineLevelValue",9.0f);
                break;
        }
    }

    public void LoadRotationSpeed()
    {
        if (PlayerPrefs.GetInt("RotationSpeedIndex")==0)
        {
            PlayerPrefs.SetInt("RotationSpeedIndex", 1);
        }

        switch (PlayerPrefs.GetInt("RotationSpeedIndex"))
        {
            case 1 :
                rotationSpeedText.GetComponent<TextMeshProUGUI>().text = "Level 1";
                PlayerPrefs.SetFloat("RotationSpeedValue",60f);
                break;
            
            case 2 :
                rotationSpeedText.GetComponent<TextMeshProUGUI>().text = "Level 2";
                PlayerPrefs.SetFloat("RotationSpeedValue",75f);
                break;
            
            case 3 :
                rotationSpeedText.GetComponent<TextMeshProUGUI>().text = "Level 3";
                PlayerPrefs.SetFloat("RotationSpeedValue",90f);
                break;
        }
    }
   
    public void LoadTurretRotationSpeed()
    {
        if (PlayerPrefs.GetInt("TurretRotationSpeedIndex")==0)
        {
            PlayerPrefs.SetInt("TurretRotationSpeedIndex", 1);
        }

        switch (PlayerPrefs.GetInt("TurretRotationSpeedIndex"))
        {
            case 1 :
                turretRotationSpeedText.GetComponent<TextMeshProUGUI>().text = "    Level 1";
                PlayerPrefs.SetFloat("TurretRotationSpeedValue",35f);
                break;
            
            case 2 :
                turretRotationSpeedText.GetComponent<TextMeshProUGUI>().text = "    Level 2";
                PlayerPrefs.SetFloat("TurretRotationSpeedValue",55f);
                break;
            
            case 3 :
                turretRotationSpeedText.GetComponent<TextMeshProUGUI>().text = "    Level 3";
                PlayerPrefs.SetFloat("TurretRotationSpeedValue",75f);
                break;
        }
    }
    
  
    public void LoadHealth()
    {
        if (PlayerPrefs.GetInt("HealthIndex")==0)
        {
            PlayerPrefs.SetInt("HealthIndex", 1);
        }

        switch (PlayerPrefs.GetInt("HealthIndex"))
        {
            case 1 :
                healthText.GetComponent<TextMeshProUGUI>().text = "    Level 1";
                PlayerPrefs.SetFloat("HealthValue",100);
                break;
            
            case 2 :
                healthText.GetComponent<TextMeshProUGUI>().text = "    Level 2";
                PlayerPrefs.SetFloat("HealthValue",120);
                break;
            
            case 3 :
                healthText.GetComponent<TextMeshProUGUI>().text = "    Level 3";
                PlayerPrefs.SetFloat("HealthValue",150);
                break;
        }
    }
    
    
    public void LoadReloadSpeed()
    {
        if (PlayerPrefs.GetInt("ReloadSpeedIndex")==0)
        {
            PlayerPrefs.SetInt("ReloadSpeedIndex", 1);
        }

        switch (PlayerPrefs.GetInt("ReloadSpeedIndex"))
        {
            case 1 :
                reloadSpeedText.GetComponent<TextMeshProUGUI>().text = "       Level 1";
                PlayerPrefs.SetFloat("ReloadSpeedValue",3.5f);
                break;
            
            case 2 :
                reloadSpeedText.GetComponent<TextMeshProUGUI>().text = "       Level 2";
                PlayerPrefs.SetFloat("ReloadSpeedValue",2.2f);
                break;
            
            case 3 :
                reloadSpeedText.GetComponent<TextMeshProUGUI>().text = "       Level 3";
                PlayerPrefs.SetFloat("ReloadSpeedValue",1.5f);
                break;
        }
    }
}
