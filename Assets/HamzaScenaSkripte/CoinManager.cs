using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

   [SerializeField] public int coinAmount = 0;
   
   
   void Start()
   {
      coinAmount = 0;
   }
   
   public void AddCoins(int amount)
   {
      coinAmount += amount;
   }

   public int GetTotalCoins()
   {
      return coinAmount;
   }
   
   
}
