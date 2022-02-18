using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Finish;
    public GameObject Player;
    public GameObject Key;
    public GameObject Door;
    public TextMeshProUGUI donutNumber;
    public TextMeshProUGUI triesTaken;
    public TextMeshProUGUI KeyInfo;
    public TextMeshProUGUI Timer;
    public int deathCount;
    public int maxDeath;
    public int DonutCount;
    public int MaxCount;
    private int timeDeduction;
    public float CurrentTime;
    public float StartTime;
    public bool GameIsOver;
    public bool PlayerWin;
    public GameObject winScreen;
    public GameObject loseScreen;
    public AudioSource music;


    //Story
    public float typeSpeed;
    public Canvas gameEnd;
    public TextMeshProUGUI textDisplay;
    public Button continueButton;
    private int index;
    [TextArea(3,10)]
    public string[] sentences;

    // Start is called before the first frame update
    void Start()
    {
        GameIsOver = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        DonutCount = 0;
        deathCount = 0;
        timeDeduction = 1;
        CurrentTime = StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Key and Door
        if (Key.GetComponent<KeyScript>().playerHasKey == true)
        {
            Door.GetComponent<BoxCollider2D>().enabled = false;
            KeyInfo.text = "Key Acquired!";
        }
        else if (Key.GetComponent<KeyScript>().playerHasKey == false)
        {
            KeyInfo.text = "No Key Found";
        }

        //Timer
        CurrentTime -= timeDeduction * Time.deltaTime;
        Timer.text = "TIMER: " + CurrentTime.ToString("0");
        if(CurrentTime <= 0)         
        {
            CurrentTime = 0;
        }

        // Death and Food Count
        triesTaken.text = "ATTEMPTS: " + deathCount;
        donutNumber.text = "" + DonutCount + "/" + MaxCount;

        //Pause
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }
        //Finish Line Rquirements Complete
        if (DonutCount == MaxCount)
        {
            Finish.SetActive(true);
        }
        //Timer 0 is Game Over
        if (CurrentTime == 0)
        {
            loseScreen.SetActive(true);
            Time.timeScale = 0f;
            CurrentTime = StartTime;
            GameIsOver = true;
        }
        if (PlayerWin == true)
        {
            winScreen.SetActive(true);
            GameIsOver = true;
        }
        if (GameIsOver == true)
        {
            music.enabled = false;
            timeDeduction = 0;
        }
        //Story
        if (textDisplay.text == sentences[index])
        {
            continueButton.gameObject.SetActive(true);
        }
    }

    IEnumerator TypeStory()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void Next()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void FinalNext()
    {
        StartCoroutine(TypeStory());
        Time.timeScale = 1f;
    }

    public void Back()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        GameIsOver = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    //Story
    public void Continue()
    {
        continueButton.gameObject.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeStory());
        }
        else
        {
            textDisplay.text = "";
            SceneManager.LoadScene("EndScene");
        }
    }

}
