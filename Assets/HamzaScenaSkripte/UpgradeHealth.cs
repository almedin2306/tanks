using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHealth : MonoBehaviour
{
    private int fromLevel1ToLevel2 = 150;
    private int fromLevel2ToLevel3 = 300;
    

    [SerializeField] private LoadData lD;

    private int currentUpgradeIndex;
    private int coinAmount;
    
    [SerializeField] private NotificationWindow myNotificationWindow;


   
    
    
    



    void Start()
    {
       
        currentUpgradeIndex = PlayerPrefs.GetInt("HealthIndex");
        coinAmount = PlayerPrefs.GetInt("CoinAmount");
        
        
    }

    void Update()
    {
        currentUpgradeIndex = PlayerPrefs.GetInt("HealthIndex");
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
                    PlayerPrefs.SetInt("HealthIndex", 2);
                    lD.LoadHealth();
                    lD.LoadCoinAmount();
                    OpenNotificationWindow("Health successfully upgraded from level 1 to level 2");
                }
                else
                {
                    OpenNotificationWindow("You do not have enough money to upgrade health from level 1 to level 2");
                }
                
                break;
           
            
            case 2:
                if (coinAmount >= fromLevel2ToLevel3)
                {
                    PlayerPrefs.SetInt("CoinAmount", PlayerPrefs.GetInt("CoinAmount") - fromLevel2ToLevel3);
                    PlayerPrefs.SetInt("HealthIndex", 3);
                    OpenNotificationWindow("Health successfully upgraded from level 2 to level 3");
                    lD.LoadHealth();
                    lD.LoadCoinAmount();
                }
                else
                {
                    OpenNotificationWindow("You do not have enough money to upgrade health from level 2 to level 3");
                    
                }
                break;
            
            case 3:
                OpenNotificationWindow("You have already upgraded health to the max level");
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
