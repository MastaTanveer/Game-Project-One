using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Endless_Manager : MonoBehaviour
{
    private GameObject player;
    private GameObject feet;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI FinalScore;
    public float gameScore;
    public GameObject groundOB;
    public GameObject aerialOB;
    public GameObject gSpawn;
    public GameObject aSpawn;
    public GameObject Results;
    public bool isGameOver;

    //Dialogue Section
    public float typeSpeed;
    public Canvas ContinueToEnd;
    public TextMeshProUGUI dialougeDisplay;
    public Button continueButton;
    private int index;
    [TextArea(3, 10)]
    public string[] sentences;
   
    // Start is called before the first frame update
    void Start()
    {
        gameScore = 0;
        groundOB.GetComponent<Obstacle_Script>().speed = 8;
        aerialOB.GetComponent<Obstacle_Script>().speed = 10;
        player = GameObject.Find("Actual Player");
        feet = GameObject.Find("Feet");
    }

    // Update is called once per frame
    void Update()
    {
        gameScore += 30 * Time.deltaTime;
        ScoreText.text = "Score: " + gameScore.ToString("0");

        //Stage Control
        if (gameScore > 1000)
        {
            Act1();
            if (gameScore > 2000)
            {
                Act2();
            }
        }

        if (dialougeDisplay.text == sentences[index])
        {
            continueButton.gameObject.SetActive(true);
        }

        //GameOver Screen and Results Information Revealed after Losing
        if (isGameOver == true)
        {
            gameObject.GetComponent<AudioSource>().enabled = false;
            if (gameScore > PlayerPrefs.GetFloat("Highscore", 0))
            {
                PlayerPrefs.SetFloat("Highscore", gameScore);
            }
            HighScore.text = "Highscore: " + PlayerPrefs.GetFloat("Highscore", 0).ToString("0") + " #";
            Time.timeScale = 0f;
            FinalScore.text = "Score: " + gameScore.ToString("0");
            Results.SetActive(true);
            isGameOver = false;
        }
        
    }

    //Dialouge Process
    IEnumerator Typing()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            dialougeDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    //Retry Button
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        groundOB.GetComponent<Obstacle_Script>().speed = 8;
        aerialOB.GetComponent<Obstacle_Script>().speed = 10;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }
    public void ResetScores()
    {
        PlayerPrefs.DeleteKey("Highscore");
    }

    public void Act1()
    {
        groundOB.GetComponent<Obstacle_Script>().speed = 10;
        gSpawn.GetComponent<Ground_Spawner>().spawnCoolDown = 1.2f;
        aerialOB.GetComponent<Obstacle_Script>().speed = 11;
        aSpawn.GetComponent<Aerial_Spawner>().spawnCoolDown = 9;
    }

    public void Act2()
    {
        groundOB.GetComponent<Obstacle_Script>().speed = 13;
        gSpawn.GetComponent<Ground_Spawner>().spawnCoolDown = 1f;
        aerialOB.GetComponent<Obstacle_Script>().speed = 15;
        aSpawn.GetComponent<Aerial_Spawner>().spawnCoolDown = 10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isGameOver = true;
        }
    }

    //Dialigue Continue
    public void Continue()
    {

        continueButton.gameObject.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            dialougeDisplay.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            dialougeDisplay.text = "";
            ContinueToEnd.gameObject.SetActive(false);
            SceneManager.LoadScene("EndScene");
        }
    }
    public void OnPress()
    {
        StartCoroutine(Typing());
        Time.timeScale = 1f;
        player.GetComponent<Endless_PlayerScript>().speed = 0;
        feet.GetComponent<PolygonCollider2D>().enabled = false;

    }
}
