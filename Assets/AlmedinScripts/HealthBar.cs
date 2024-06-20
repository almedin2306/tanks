using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage; // Reference to the UI Image representing the health bar
    public PlayerStats playerStats; // Reference to the PlayerStats script controlling the tank's health

    private void Update()
    {
        // Update the health bar fill amount based on the tank's current health
        if (playerStats != null && healthBarImage != null)
        {
            float fillAmount = playerStats.PlayerHealth / PlayerPrefs.GetFloat("HealthValue"); // Assuming PlayerHealth ranges from 0 to 100
            healthBarImage.fillAmount = fillAmount;
            
        }
    }
}
