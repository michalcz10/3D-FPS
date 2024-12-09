using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackAngle = 45f;
    public float attackCooldown = 2f;
    public int damage = 10;

    private Transform player;
    private float lastAttackTime;
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found! Ensure the player has the tag 'Player'.");
        }
    }

    void Update()
    {
        if (player == null) return;

        if (IsPlayerInFront() && IsPlayerInRange())
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
    }

    private bool IsPlayerInFront()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        return angle <= attackAngle / 2;
    }

    private bool IsPlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer <= attackRange;
    }

    private void AttackPlayer()
    {
        Debug.Log("Enemy attacks the player!");

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Health -= damage;
        }
        else
        {
            Debug.LogWarning("PlayerHealth script not found on the player!");
        }
    }
}
