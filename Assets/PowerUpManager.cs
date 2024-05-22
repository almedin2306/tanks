using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
   
    public static PowerUpManager Instance; // Singleton instance

    private float currentPlayerBulletDamage = 20f;
    private float currentEnemyBulletDamage = 20f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ModifyBulletDamage(float amount)
    {
        currentPlayerBulletDamage += amount;
    }


    public void ResetBulletDamage()
    {
        currentPlayerBulletDamage = 20f; // Reset bullet damage to default
    }

    // Getter for current bullet damage
    public float GetCurrentBulletDamage()
    {
        return currentPlayerBulletDamage;
    }
	public void ModifyEnemyBulletDamage(float amount)
    {
        currentEnemyBulletDamage += amount;
    }
	public void ResetEnemyBulletDamage()
    {
        currentEnemyBulletDamage = 20f; // Reset bullet damage to default
    }
	public float GetCurrentEnemyBulletDamage()
    {
        return currentEnemyBulletDamage;
    }

}
