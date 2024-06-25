using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
  public GameObject trailPrefab;  // Assign the trail prefab in the inspector
      private GameObject trailInstance;
  
      void Start()
      {
          if (trailPrefab != null)
          {
              // Instantiate the trail and make it a child of the rocket
              trailInstance = Instantiate(trailPrefab, transform.position, Quaternion.identity);
              trailInstance.transform.SetParent(transform);
              Debug.Log("Trail instantiated and parented to rocket.");
          }
          else
          {
              Debug.LogError("Trail prefab is not assigned.");
          }
      }
  
      void Update()
      {
          // Example movement logic for the rocket (this should be replaced with actual movement logic)
          transform.Translate(Vector3.forward * Time.deltaTime);
      }
}
