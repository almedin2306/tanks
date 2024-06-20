using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damageAmount; // Amount of damage the bullet deals
    public AudioClip shotAudioClip; 
    
    public GameObject hitEffectPrefab;

    
  
    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(shotAudioClip, transform.position);
        Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        float damage = PowerUpManager.Instance.GetCurrentEnemyBulletDamage();
        if (!collision.gameObject.CompareTag("TankFree_Red"))
        {
            if (collision.gameObject.CompareTag("TankFree_Blue"))
            {

                // Reduce the player's health by the damage amount
                collision.gameObject.GetComponent<PlayerStats>().PlayerHealth -= damageAmount;

            }

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Destroyable"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}