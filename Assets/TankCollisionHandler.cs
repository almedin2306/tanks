using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DestroyableSmall"))
        {
            Destroy(collision.gameObject);
        }
    }
}
