using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private int scoreValue;
    private float health;
    private Transform player;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            if(value <= 0f)
            {
                Destroy(gameObject);
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                playerHealth.AddScore(scoreValue);
            }
            else health = value;
        }
    }

    void Start()
    {
        Health = startingHealth;

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
}
