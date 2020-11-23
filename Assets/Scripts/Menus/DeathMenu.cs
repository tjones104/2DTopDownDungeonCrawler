using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject gameOverMenuUI;

    public void EndGame()
    {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        AudioManager.instance.StopPlaying("Theme");
        PauseMenu.GameIsPaused = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        AudioManager.instance.Play("Main Menu");
        SceneManager.LoadScene("MainMenu");
    }
}
