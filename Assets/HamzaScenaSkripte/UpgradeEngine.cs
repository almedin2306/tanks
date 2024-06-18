using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeEngine : MonoBehaviour
{
    private int fromLevel1ToLevel2 = 150;
    private int fromLevel2ToLevel3 = 300;
    

    private LoadData lD;

    private int currentUpgradeIndex;
    private int coinAmount;
    
    [SerializeField] private NotificationWindow myNotificationWindow;


  
    
    
    



    void Start()
    {
       
        currentUpgradeIndex = PlayerPrefs.GetInt("EngineLevelIndex");
        coinAmount = PlayerPrefs.GetInt("CoinAmount");
        
        
    }

    


    public void TryToUpgrade()
    {
        
        
        
        
        switch (currentUpgradeIndex)
        {
            case 1:
                
                if (coinAmount >= fromLevel1ToLevel2)
                {
                    PlayerPrefs.SetInt("CoinAmount", PlayerPrefs.GetInt("CoinAmount") - fromLevel1ToLevel2);
                    PlayerPrefs.SetInt("EngineLevelIndex", 2);
                    OpenNotificationWindow("Engine successfully upgraded from level 1 to level 2");
                    lD.LoadEngineLevel();
                    lD.LoadCoinAmount();
                }
                else
                {
                    OpenNotificationWindow("You do not have enough money to upgrade the engine from level 1 to level 2");
                }
                
                break;
           
            
            case 2:
                if (coinAmount >= fromLevel2ToLevel3)
                {
                    PlayerPrefs.SetInt("CoinAmount", PlayerPrefs.GetInt("CoinAmount") - fromLevel2ToLevel3);
                    PlayerPrefs.SetInt("EngineLevelIndex", 3);
                    OpenNotificationWindow("Engine successfully upgraded from level 2 to level 3");
                    lD.LoadEngineLevel();
                    lD.LoadCoinAmount();
                }
                else
                {
                    OpenNotificationWindow("You do not have enough money to upgrade the engine from level 2 to level 3");
                    
                }
                break;
            
            case 3:
                OpenNotificationWindow("You have already upgraded the engine to the max level");
                break;
        }
        
    }
    
    private void OpenNotificationWindow(string message)
    {
        myNotificationWindow.gameObject.SetActive(true);
        myNotificationWindow.notificationWindowText.text = message;
        StartCoroutine(HideNotificationWindowAfterDelay(3f));
    }
    private IEnumerator HideNotificationWindowAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        myNotificationWindow.gameObject.SetActive(false);
    }
    
    
  
}
