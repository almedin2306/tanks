using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform tank;          // Reference to the tank's transform
    public Transform turret;        // Reference to the tank's turret's transform
    public float distance = 10f;    // Distance from the tank
    public float height = 5f;       // Height above the tank
    public float rotationDamping = 5f; // Damping for camera rotation
    public float maxPitchAngle = 45f; // Maximum pitch angle
    public float maxRollAngle = 10f;  // Maximum roll angle
    public float angleThreshold = 90f; // Threshold angle for switching camera position

    private bool isBehindTank = true; // Flag to track camera position relative to the tank

    void Start()
    {
        // Offset the initial position of the camera by 10 units behind the tank's initial position
        Vector3 initialOffset = tank.position - tank.forward * distance;
        transform.position = initialOffset + Vector3.up * height;
    }

    void Update()
    {
        // Calculate the desired position of the camera based on spherical coordinates
        Vector3 offset = isBehindTank ? new Vector3(0f, height, -distance) : new Vector3(0f, height, distance);
        Vector3 desiredPosition = tank.position + tank.TransformDirection(offset);

        // Update the camera's position smoothly
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);

        // Calculate the direction from the camera to the tank's position
        Vector3 lookDirection = tank.position - transform.position;

        // Rotate the camera to always face the tank
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationDamping * Time.deltaTime);

        // Rotate the camera around the tank based on the turret's rotation
        float turretRotationY = turret.eulerAngles.y; // Get the turret's rotation around the Y axis
        transform.RotateAround(tank.position, Vector3.up, turretRotationY - transform.eulerAngles.y);

        // Check if the turret is facing towards the camera
        float angle = Quaternion.Angle(transform.rotation, turret.rotation);
        if (angle < angleThreshold || angle > 360 - angleThreshold)
        {
            isBehindTank = false;
        }
        else
        {
            isBehindTank = true;
        }

        // Clamp the camera's rotation on the x-axis (pitch)
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.x = Mathf.Clamp(eulerAngles.x, -maxPitchAngle, maxPitchAngle);

        // Clamp the camera's rotation on the z-axis (roll)
        eulerAngles.z = Mathf.Clamp(eulerAngles.z, -maxRollAngle, maxRollAngle);

        transform.eulerAngles = eulerAngles;
    }
}

