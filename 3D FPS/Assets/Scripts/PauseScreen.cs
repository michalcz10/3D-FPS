using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void RestartButtonn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }  

    public void ExitButtonn()
    {
        Application.Quit();
    }

    public void ContinueButtonn()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SettingButtonn()
    {
        settingsMenu.SetActive(true);
    }
}
