using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTankStats : MonoBehaviour
{
    public float PlayerHealth = 100; // Maximum health of the player
   

    [Header("Respawn")]
    public Transform respawnPoint; // Respawn point for the player

    [Header("Audio")]
    public AudioClip shootSound; // Sound clip to play when shooting

    [Header("Visual Effects")]
    public ParticleSystem muzzleFlash; // Particle effect for muzzle flash

    public EnemySpawner spawn; // Reference to the SpawnManager script

	public GameObject explosionEffect;

    public CoinManager coinManager;
    public CoinUI coinUI;

    // Other properties, methods, and events related to player stats can be added here

    // Function to respawn the playerpublic void RespawnPlayer()
    
    void Start()
    {
        spawn = FindObjectOfType<EnemySpawner>();
        if (spawn == null)
        {
            Debug.LogWarning("EnemySpawner reference not found!");
        }

        coinManager = FindObjectOfType<CoinManager>();
        if (coinManager == null)
        {
            Debug.LogError("CoinManager not found in the scene!");
        }

        coinUI = FindObjectOfType<CoinUI>();

    }
    private void Update()
    {
        // Check if the player's health is 0 or below
        if (PlayerHealth <= 0 ) // Adjust the y threshold as needed
        {

            if (gameObject.layer == 6)
            {
                coinManager.AddCoins(5);
            }
            else if (gameObject.layer == 9)
            {
                coinManager.AddCoins(10);
            }
            else
            {
                coinManager.AddCoins(15);
            }
            
            coinUI.showAmountOfCoins();
            
            spawn.EnemyDestroyed(); // Call the EnemyDestroyed function in the SpawnManager
            Destroy(gameObject); // Destroy the enemy object
           // StartCoroutine(DestroyAfterDelay(0.2f));
            
            
        }
    }

	//private IEnumerator DestroyAfterDelay(float delay)
    /// if (explosionEffect != null)
       // {
         //   Instantiate(explosionEffect, transform.position, transform.rotation);
        //}

       // yield return new WaitForSeconds(delay); // Wait for the specified delay

       // spawn.EnemyDestroyed(); // Call the EnemyDestroyed function in the SpawnManager
       // Destroy(gameObject); // Destroy the enemy object
   // }
    
    // Call this function when an enemy is destroyed
   
}
