using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject hitEffectPrefab; // Prefab efekta koji će se prikazati na mjestu pogotka
    public float explosionRadius = 5f; // Radijus eksplozije

    private bool hasExploded = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        // Instanciraj efekt pogotka na mjestu eksplozije
        Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

        /*// Detektiraj objekte unutar radijusa eksplozije
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Target"))
            {
                // Pokreni jednostavnu animaciju na ciljnom objektu (ako ima Animator komponentu)
                Animator animator = collider.gameObject.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetTrigger("Hit"); // Pokreće se trigger za animaciju "Hit"
                }
            }
        }*/

        // Uništi granatu nakon eksplozije
        Destroy(gameObject);
    }
}
