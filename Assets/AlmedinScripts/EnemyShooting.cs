using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float shootingDistance = 15f; // Distance threshold to start shooting
    public float shootingInterval = 1f; // Interval between shots
    public GameObject bulletPrefab; // Prefab of the bullet to shoot
    public Transform firePoint; // Position to spawn bullets from
    public float bulletDestroyDelay = 10f; // Delay before bullets are destroyed

    private float lastShotTime; // Time when the last shot was fired
    private Quaternion desiredRotation; // Desired rotation to face the player

    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // Check if the player is within shooting distance
        if (distanceToPlayer <= shootingDistance)
        {
            // Rotate towards the player's position
            RotateTowardsPlayer();

            // Check if enough time has passed since the last shot
            if (Time.time - lastShotTime >= shootingInterval)
            {
                Shoot(); // Start shooting
                lastShotTime = Time.time; // Update the last shot time
            }
        }
    }

    void RotateTowardsPlayer()
    {
        // Calculate the direction to the player
        Vector3 directionToPlayer = playerTransform.position - transform.position;

        // Create a rotation to face the player
        desiredRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

        // Smoothly rotate towards the desired rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, Time.deltaTime * 180);
    }

    void Shoot()
    {
        // Instantiate a bullet at the fire point's position and rotation
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Start a coroutine to destroy the bullet after a delay
        StartCoroutine(DestroyBullet(newBullet));
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(bulletDestroyDelay);

        // Destroy the bullet after the delay
        Destroy(bullet);
    }
}
