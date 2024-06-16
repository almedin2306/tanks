using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleNotification : MonoBehaviour
{
    public GameObject notificationPrefab; // Prefab forme
    private GameObject currentNotification; // Trenutna instanca forme

    public void ShowNotification(string message)
    {
        if (currentNotification != null)
        {
            Destroy(currentNotification); // Uništite prethodnu instancu ako postoji
        }

        currentNotification = Instantiate(notificationPrefab, transform);
        currentNotification.transform.SetParent(transform, false); // Dodajte kao dete trenutnog objekta

        Text messageText = currentNotification.transform.Find("Text").GetComponent<Text>();
        messageText.text = message;

        Button okButton = currentNotification.transform.Find("OKButton").GetComponent<Button>();
        

        okButton.onClick.RemoveAllListeners();
        okButton.onClick.AddListener(() => 
        {
            Debug.Log("OK button clicked");
            Destroy(currentNotification); // Uništite instancu forme
        });

        
    }
}
