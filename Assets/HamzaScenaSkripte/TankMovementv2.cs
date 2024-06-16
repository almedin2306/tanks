using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovementv2 : MonoBehaviour
{
    public float moveSpeed;
    public float OriginalSpeed = 3.0f;
    public float rotationSpeed;
    public GameObject[] leftWheels;
    public GameObject[] rightWheels;

    public float wheelRotationSpeed = 150.0f;

    private Rigidbody rb;
    private float moveInput;
    private float rotationInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = PlayerPrefs.GetFloat("EngineLevelValue");
        rotationSpeed = PlayerPrefs.GetFloat("RotationSpeedValue");
    }

    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");
        
        RotateWheels(moveInput,rotationInput);
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

        Vector3 moveDirection = transform.forward * input * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);
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
//Move the left wheels
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