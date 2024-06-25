using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public float launchSpeed = 75.0f;
    public GameObject objectPrefab;
    public float cooldownDuration; // Vrijeme u sekundama između ispaljivanja
    private bool canFire = true; // Da li je trenutno moguće ispaljivanje
    public static bool isFired=false;
    public GameObject EffectPrefab;
    public AudioClip shotAudioClip;

    // Update is called once per frame

    private void Start()
    {
        cooldownDuration = PlayerPrefs.GetFloat("ReloadSpeedValue");
    }

    void Update()
    {
        if (canFire && Input.GetKeyDown("space"))
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        if (canFire)
        {
            Vector3 spawnPosition = transform.position;
        
            Vector3 localXDirection = transform.TransformDirection(Vector3.forward);
            Vector3 velocity = localXDirection * launchSpeed;
        
            // Instanciranje objekta
            GameObject newObject = Instantiate(objectPrefab, spawnPosition, transform.rotation);
            Rigidbody rb = newObject.GetComponent<Rigidbody>();
            rb.velocity = velocity;
            // Offset position for the effect
            Vector3 effectSpawnPosition = spawnPosition + localXDirection * 1.0f; // Adjust 1.0f as needed
        
            // Calculate rotation for the effect (rotated 90 degrees around y-axis)
            Quaternion effectRotation = Quaternion.Euler(0f, 90f, 0f) * newObject.transform.rotation;
        
            // Instanciranje efekta s pomaknutom pozicijom i rotacijom
            GameObject effect = Instantiate(EffectPrefab, effectSpawnPosition, effectRotation);
        
            // Dajte efektu brzinu prema lokalnoj X smjeru (forward smjer)
            Rigidbody effectRB = effect.GetComponent<Rigidbody>();
            effectRB.velocity = localXDirection * launchSpeed * 0.1f; // Adjust 0.1f for the desired speed
            
            AudioSource.PlayClipAtPoint(shotAudioClip, transform.position);
            
            StartCoroutine(StartCooldown());
            StartCoroutine(DestroyObjectAfterDelay(newObject, 3.0f));
        }
    }
    
    IEnumerator DestroyObjectAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj); // Uništavanje objekta nakon određenog vremena
    }
    
    IEnumerator StartCooldown()
    {
        canFire = false; // Postavite da ispaljivanje nije trenutno moguće
        isFired = true;
       
        // Pričekajte cooldownDuration sekundi prije nego što ponovno omogućite ispaljivanje
        yield return new WaitForSeconds(cooldownDuration);
        canFire = true; // Omogućite ispaljivanje ponovo
        isFired = false;
    }
}