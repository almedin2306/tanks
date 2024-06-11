using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TankInventory : MonoBehaviour
{
    public int numberOfEnemiesKilled { get; private set; }
    
    public int numberOfCoinsEarned { get; private set; }

    public void EnemyKilled()
    {
        numberOfEnemiesKilled++;
    }
    
    
    public void AddCoins(string tag)
    {
        
                if (tag == "redEnemy")
                {
                    numberOfCoinsEarned += 20;
                    
                }
                else    if (tag == "greenEnemy")
                {
                    numberOfCoinsEarned += 5;
                    
                }
                else
                {
                    numberOfCoinsEarned += 10;
                }
                
    }
    
    
}
