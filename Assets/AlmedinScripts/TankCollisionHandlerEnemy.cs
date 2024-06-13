using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollisionHandlerEnemy : MonoBehaviour
{
    
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        if (other.CompareTag("DestroyableSmall"))
        {
            Debug.Log("DestroyableSmall Object Detected");
            Destroy(other.gameObject);
        }
    
}
    
}
