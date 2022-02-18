using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public KeyCode PauseButton;
    public GameObject pauseMenuUI;
    public GameObject InfoBar;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(PauseButton))
        {
            GameIsPaused = true;
            if (GameIsPaused == true)
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        InfoBar.SetActive(false);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        InfoBar.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
        Debug.Log("Loading...");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("You Quit the Game!");
    }

}
