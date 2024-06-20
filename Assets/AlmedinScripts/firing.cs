using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class firing : MonoBehaviour
{
     private Transform playerTransform; // Reference to the player's transform
    public GameObject bulletPrefab; // Prefab of the bullet to shoot
    public Transform firePoint; // Position to spawn bullets from
    public float shootingDistance = 15f; // Distance threshold to start shooting
    public float shootingCooldown = 3f; // Cooldown between shots
    private float lastShotTime; // Time when the last shot was fired
    public float bulletDestroyDelay = 10f; // Delay before bullets are destroyed

    public AudioClip shotAudioClip;
    void Start()
    {
        // Find the player tank GameObject with the "Player" tag
        GameObject playerTank = GameObject.FindGameObjectWithTag("TankFree_Blue");
        if (playerTank != null)
        {
            playerTransform = playerTank.transform;
        }
        else
        {
            Debug.LogError("Player tank not found in the scene.");
        }
    }

    void Update()
    {
        if (playerTransform == null)
            return;

        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // Check if the player is within shooting distance and the enemy is rotated towards the player
        if (distanceToPlayer <= shootingDistance && IsFacingPlayer())
        {
            // Check if enough time has passed since the last shot
            if (Time.time - lastShotTime >= shootingCooldown)
            {
                Shoot(); // Start shooting
                lastShotTime = Time.time; // Update the last shot time
            }
        }
    }

    bool IsFacingPlayer()
    {
        if (playerTransform == null)
            return false;

        // Calculate the direction to the player
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        directionToPlayer.y = 0f; // Ignore vertical direction

        // Calculate the angle between the forward direction of the enemy and the direction to the player
        float angle = Vector3.Angle(transform.forward, directionToPlayer);

        // Check if the angle is within a certain threshold (e.g., 30 degrees)
        return angle <= 30f; // Adjust the threshold angle as needed
    }

    void Shoot()
    {
        AudioSource.PlayClipAtPoint(shotAudioClip, transform.position);
        // Instantiate a bullet at the fire point's position and rotation
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Access the bullet's Rigidbody component
        Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();

        // Calculate the shooting direction towards the player
        Vector3 shootingDirection = (playerTransform.position - firePoint.position).normalized;

        // Adjust the bullet speed here (e.g., multiply by a speed value)
        float bulletSpeed = 30f; // Adjust the speed as needed

        // Apply the velocity to the bullet's Rigidbody component
        bulletRigidbody.velocity = shootingDirection * bulletSpeed;

        // Destroy the bullet after the specified delay
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

