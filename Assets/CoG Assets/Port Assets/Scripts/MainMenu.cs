using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {

    }

    public void StartGame()
    {
        LoadGame();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(4);
    }
}
