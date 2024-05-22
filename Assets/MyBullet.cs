using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBullet : MonoBehaviour
{
    public float damageAmount = 20; // Amount of damage the bullet deals

    private void OnCollisionEnter(Collision collision)
    {
        float damage = PowerUpManager.Instance.GetCurrentBulletDamage();
        if (!collision.gameObject.CompareTag("TankFree_Blue"))
        {
            if (collision.gameObject.CompareTag("TankFree_Red"))
            {
                // Reduce the player's health by the damage amount
                collision.gameObject.GetComponent<PlayerStats>().PlayerHealth -= damage;
                    
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