using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ailocomotion : MonoBehaviour
{
    public Transform playerTransform;
    private NavMeshAgent agent;
    public float rotationSpeed = 180f; // Adjust rotation speed as needed
    public float detectionRange = 10f; // The range within which the AI detects the player

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // Check if the player is within the detection range
        if (distanceToPlayer <= detectionRange)
        {
            // Calculate the direction to the player
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

            // Calculate the rotation towards the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

            // Smoothly rotate towards the player's direction
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Set the destination to the player's position regardless of distance
        agent.SetDestination(playerTransform.position);
    }
}