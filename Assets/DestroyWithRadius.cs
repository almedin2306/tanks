using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithRadius : MonoBehaviour
{
    
        public float destroyRadius = 3f;
    
        private void OnDestroy()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, destroyRadius);
    
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Destroyable") || col.CompareTag("DestroyableSmall"))
                {
                    Destroy(col.gameObject);
                }
            }
        }
    

}
