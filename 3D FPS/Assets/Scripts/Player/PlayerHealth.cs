using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float health;
    public TextMeshProUGUI healthMonitor;
    public GameOverScreen gameOverScreen;
    private int score = 0;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            healthMonitor.text = "Health: " + health;
            if(health <= 0f)
            {
                playerDestroy();
            }
        }
    }
    void Start()
    {
        Health = startingHealth;
    }

    private void playerDestroy()
    {
        gameOverScreen.TriggerScreen(score);
    }

    public void AddScore(int n)
    {
        score += n;
    }
}
