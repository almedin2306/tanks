using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of enemy prefabs
    public Transform[] spawnPoints;   // Array of spawn points

    private int totalEnemiesSpawned = 0;
    private int maxEnemies = 5;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        while (totalEnemiesSpawned < maxEnemies)
        {
            // Randomly select an enemy type based on probabilities
            float rand = Random.value;
            GameObject enemyPrefab = null;

            if (rand <= 0.5f)
                enemyPrefab = enemyPrefabs[0]; // Easiest enemy
            else if (rand <= 0.85f)
                enemyPrefab = enemyPrefabs[1]; // Second enemy
            else
                enemyPrefab = enemyPrefabs[2]; // Hardest enemy

            // Randomly select a spawn point
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Spawn the enemy at the chosen spawn point
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            totalEnemiesSpawned++;
        }
    }

    public void EnemyDestroyed()
    {
        totalEnemiesSpawned--;
        if (totalEnemiesSpawned < maxEnemies)
            SpawnEnemies(); // Respawn a new enemy
    }
}
