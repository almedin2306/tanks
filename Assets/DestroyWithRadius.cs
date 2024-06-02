using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithRadius : MonoBehaviour
{
    
    public float destroyRadius = 3f;
    public GameObject explosionPrefab; // Prefab of the explosion effect

    private void OnDestroy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, destroyRadius);

        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Destroyable") || col.CompareTag("DestroyableSmall"))
            {
                // Instantiate explosion effect at the position of the destroyed object
                Instantiate(explosionPrefab, col.transform.position, Quaternion.identity);
                Destroy(col.gameObject);
            }
        }
    }

}
