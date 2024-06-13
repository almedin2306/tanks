using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGroundCheck : MonoBehaviour

{
    public Transform respawnPoint; // Respawn point for the tank

    void Update()
    {
        // Check if the tank has fallen below the map
        if (transform.position.y < -10f) // Adjust the y threshold as needed
        {
            RespawnTank();
        }
    }

    void RespawnTank()
    {
         // Move the tank to the respawn point's position
    transform.position = respawnPoint.position;
    
    // Set the tank's rotation to match the respawn point's rotation
    transform.rotation = respawnPoint.rotation;
    }
}