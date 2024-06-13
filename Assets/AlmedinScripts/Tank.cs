using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tank : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 10;

    public float speed = 5f;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void DoubleDamage()
    {
        damage *= 2;
    }

    public void SpeedBoost()
    {
        speed *= 10f; // Increase speed by 50%
    }

    public void DoubleHealth()
    {
        maxHealth *= 2;
        currentHealth = maxHealth;
    }
}
