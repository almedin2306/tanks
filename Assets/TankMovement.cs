using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
	public float OriginalSpeed = 5.0f;
    public float rotationSpeed = 120.0f;
    public GameObject[] leftWheels;
    public GameObject[] rightWheels;

    public float wheelRotationSpeed = 200.0f;
    public float maxGroundAngle = 45f; // Maximum ground angle the tank can climb

    private Rigidbody rb;
    private float moveInput;
    private float rotationInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");
        
        RotateWheels(moveInput, rotationInput);
    }


    private void FixedUpdate()
    {
        MoveTankObj(moveInput);
        RotateTank(rotationInput);
    }

public void SpeedBoost()
    {
        moveSpeed *= 1.5f; // Increase speed by 50%
    }

public void ResetSpeed()
	{
		 moveSpeed=OriginalSpeed;
	}



    void MoveTankObj(float input)
    {
        // Perform a downward raycast to detect the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            // Check if the ground angle is less than the maximum allowed angle
            if (Vector3.Angle(hit.normal, Vector3.up) < maxGroundAngle)
            {
                Vector3 moveDirection = transform.forward * input * moveSpeed * Time.fixedDeltaTime;
                rb.MovePosition(rb.position + moveDirection);
            }
        }
    }

    void RotateTank(float input)
    {
        float rotation = input * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void RotateWheels(float moveInput, float rotationInput)
    {
        float wheelRotation = moveInput * wheelRotationSpeed * Time.fixedDeltaTime;

        // Move the left wheels
        foreach (GameObject wheel in leftWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation - rotationInput * wheelRotationSpeed * Time.fixedDeltaTime, 0.0f, 0.0f);
            }
        }

        foreach (GameObject wheel in rightWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation + rotationInput * wheelRotationSpeed * Time.fixedDeltaTime, 0.0f, 0.0f);
            }
        }
    }
}
