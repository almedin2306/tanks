using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNotificationWindow : MonoBehaviour
{

    [SerializeField] private NotificationWindow myNotificationWindow;


    public void OpenNotificationWindow(string message)
    {
        myNotificationWindow.gameObject.SetActive(true);
        myNotificationWindow.notificationWindowText.text = message;
        
    }
    
}
