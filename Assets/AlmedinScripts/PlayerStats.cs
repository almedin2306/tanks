using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float PlayerHealth; // Maximum health of the player
    public float rotationSpeed = 120f; // Rotation speed of the player (degrees per second)
    public float fireRate = 0.5f; // Rate of fire (bullets per second)
    public int lives = 3; // Number of lives for the player

    public CoinManager coinManager;
    
    [Header("Respawn")]
    public Transform respawnPoint; // Respawn point for the player

    [Header("Audio")]
    public AudioClip shootSound; // Sound clip to play when shooting

    [Header("Visual Effects")]
    public ParticleSystem muzzleFlash; // Particle effect for muzzle flash

    // Other properties, methods, and events related to player stats can be added here

    public void Start()
    {
        coinManager=FindObjectOfType<CoinManager>();
        PlayerHealth = PlayerPrefs.GetFloat("HealthValue");
    }

    // Function to respawn the player
    public void RespawnPlayer()
    {
        // Reduce lives count
        lives--;

        if (lives <= 0)
        {
            // Change scene to "GameOverScene" when lives run out
            PlayerPrefs.SetInt("CoinAmount", PlayerPrefs.GetInt("CoinAmount")+coinManager.GetTotalCoins());
            SceneManager.LoadScene("Garage");
            return;
        }

        // Move the tank to the respawn point's position
        transform.position = respawnPoint.position;
    
        // Set the tank's rotation to match the respawn point's rotation
        transform.rotation = respawnPoint.rotation;
        
        // Reset the player's health
        PlayerHealth = PlayerPrefs.GetFloat("HealthValue");
    }

    private void Update()
    {
        // Check if the player's health is 0 or below
        if (PlayerHealth <= 0)
        {
            RespawnPlayer(); // Respawn the player
        }

        // Check if the player falls below a certain y position
        if (transform.position.y < -10f) // Adjust the y threshold as needed
        {
            RespawnPlayer();
        }
    }

    public void ResetHealth()
    {
        PlayerHealth = PlayerPrefs.GetFloat("HealthValue");
    }

    public float GetCurrentHealth()
    {
        return PlayerHealth;
    }
}
