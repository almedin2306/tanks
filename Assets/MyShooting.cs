using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShooting : MonoBehaviour
{
    public float launchSpeed = 75.0f;
    public GameObject objectPrefab;
    public float cooldownDuration = 2.0f; // Vrijeme u sekundama između ispaljivanja
    private bool canFire = true; // Da li je trenutno moguće ispaljivanje

    // Update is called once per frame
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

        // Pričekajte cooldownDuration sekundi prije nego što ponovno omogućite ispaljivanje
        yield return new WaitForSeconds(cooldownDuration);

        canFire = true; // Omogućite ispaljivanje ponovo
    }
}
