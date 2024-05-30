using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuretRotation : MonoBehaviour
{
    public float rotationSpeed = 90.0f;

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKey(KeyCode.Comma))
        {
            transform.Rotate(Vector3.up,-rotationSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.Period))
        {
            transform.Rotate(Vector3.up,rotationSpeed * Time.deltaTime);
        }
    }
}
