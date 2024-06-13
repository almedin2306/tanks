using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs; // Array of power-up prefabs
    public Transform[] spawnPoints; // Array of spawn points
    public float minSpawnInterval = 10f; // Minimum time interval between spawns
    public float maxSpawnInterval = 20f; // Maximum time interval between spawns

    private GameObject[] spawnedPowerUps; // Array to keep track of spawned power-ups at each spawn point

    private void Start()
    {
        spawnedPowerUps = new GameObject[spawnPoints.Length];
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

            // Loop through each spawn point
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                // Check if there's no power-up already spawned at this spawn point
                if (spawnedPowerUps[i] == null)
                {
                    // Randomly select a power-up prefab
                    GameObject powerUpPrefab = powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)];

                    // Spawn the power-up at the selected spawn point
                    GameObject powerUp = Instantiate(powerUpPrefab, spawnPoints[i].position, Quaternion.identity);

                    // Store reference to the spawned power-up at this spawn point
                    spawnedPowerUps[i] = powerUp;
                }
            }
        }
    }
}
