using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class wheelrotation : MonoBehaviour
{
    public Transform[] leftWheels; // Array of left wheel transforms
    public Transform[] rightWheels; // Array of right wheel transforms
    public float rotationSpeed = 100f; // Speed at which the wheels rotate

    void Update()
    {
        // Rotate the wheels based on tank movement
        RotateWheels();
    }

    void RotateWheels()
    {
        // Calculate wheel rotation angle based on NavMeshAgent's desired velocity
        float moveSpeed = GetComponent<NavMeshAgent>().velocity.magnitude;
        float wheelsRotation = moveSpeed * rotationSpeed * Time.deltaTime;

        // Rotate left wheels
        foreach (Transform wheel in leftWheels)
        {
            wheel.Rotate(Vector3.right, wheelsRotation);
        }

        // Rotate right wheels
        foreach (Transform wheel in rightWheels)
        {
            wheel.Rotate(Vector3.right, wheelsRotation);
        }
    }
}
