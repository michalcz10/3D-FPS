using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public CharacterController charControl;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask obstacleMask;
    public float detectionOffset = 0.5f;

    public Transform player;
    public float obstacleDetectionDistance = 1f;
    public float rotationSpeed = 5f;

    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found in the scene! Ensure the player GameObject is tagged as 'Player'.");
        }
    }


    void Update()
    {
        if(player == null) return;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Vector3 move = new Vector3(directionToPlayer.x, 0, directionToPlayer.z);

        Vector3 rayOrigin = transform.position + Vector3.down * detectionOffset;

        bool isBlocked = Physics.Raycast(rayOrigin, move, obstacleDetectionDistance, obstacleMask);

        if (isBlocked && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        charControl.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        charControl.Move(velocity * Time.deltaTime);

        RotateTowardsPlayer(directionToPlayer);
    }

    private void RotateTowardsPlayer(Vector3 directionToPlayer)
    {
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0, directionToPlayer.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            Vector3 moveDirection = new Vector3(directionToPlayer.x, 0, directionToPlayer.z);
            Vector3 rayOrigin = transform.position + Vector3.down * detectionOffset;
            Gizmos.color = Color.red;
            Gizmos.DrawRay(rayOrigin, moveDirection * obstacleDetectionDistance);
        }
    }

}
