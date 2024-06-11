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

    // Other properties, methods, and events related to player stats can be added here

    // Function to respawn the playerpublic void RespawnPlayer()
    
    void Start()
    {
        spawn = FindObjectOfType<EnemySpawner>();
        if (spawn == null)
        {
            Debug.LogWarning("EnemySpawner reference not found!");
        }
    }
    private void Update()
    {
        // Check if the player's health is 0 or below
        if (PlayerHealth <= 0 ) // Adjust the y threshold as needed
        {
            
            Destroy(gameObject);
           
                spawn.EnemyDestroyed(); // Call the EnemyDestroyed function in the SpawnManager
            
             // Respawn the player
        }
    }
    
    // Call this function when an enemy is destroyed
   
}
