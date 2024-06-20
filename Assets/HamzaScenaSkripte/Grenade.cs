using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject hitEffectPrefab; // Prefab efekta koji će se prikazati na mjestu pogotka
    public float explosionRadius = 5f; // Radijus eksplozije

    public float damageAmount = 20; // Amount of damage the bullet deals
    private bool hasExploded = false;
    public AudioClip shotAudioClip;

   
    void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(shotAudioClip, transform.position);

        if (!hasExploded)
        {
            Explode();
            hasExploded = true;
        }
        if (!hasExploded)
        {
            Explode();
            hasExploded = true;
        }
        float damage = PowerUpManager.Instance.GetCurrentBulletDamage();
        if (!collision.gameObject.CompareTag("TankFree_Blue"))
        {
            if (collision.gameObject.CompareTag("TankFree_Red"))
            {
                // Reduce the player's health by the damage amount
                collision.gameObject.GetComponent<EnemyTankStats>().PlayerHealth -= damage;
                    
            }
        }
            
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            Destroy(collision.gameObject);
            
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
