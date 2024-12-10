using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public void TriggerScreen(int score = 0)
    {
        Cursor.lockState = CursorLockMode.None;
        scoreText.text = "SCORE: " + score.ToString();
        gameObject.SetActive(true);

        Time.timeScale = 0;
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }  

    public void ExitButton()
    {
        Application.Quit();
    }
}
