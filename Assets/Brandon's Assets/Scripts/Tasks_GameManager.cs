using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Tasks_GameManager : MonoBehaviour
{
    //EndText
    public float typeSpeed;
    public Canvas NarratorBox;
    public TextMeshProUGUI NarratorText;
    public Button ContinueButton;
    private int index;
    [TextArea(3, 10)]
    public string[] sentences;
    //Text
    public TextMeshProUGUI GramStatus;
    public TextMeshProUGUI FarmStatus;
    public TextMeshProUGUI MailStatus;
    public TextMeshProUGUI TireStatus;
    //Bools
    public bool isGrandmaFinished;
    public bool isFarmerFinished;
    public bool isMailFinished;
    public bool isTruckerFinished;
    //Game Objects
    public GameObject TaskDisplay;
    public Button Finish;
    public Button Close;
    //Pause Menu
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        GramStatus.text = "Incomplete";
        FarmStatus.text = "Incomplete";
        MailStatus.text = "Incomplete";
        TireStatus.text = "Incomplete";
    }

    IEnumerator Talking()
    {
        foreach (char letterTwo in sentences[index])
        {
            NarratorText.text += letterTwo;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        //
        if (NarratorText.text == sentences[index])
        {
            ContinueButton.gameObject.SetActive(true);
        }

        //////
        ///
        //////

        if (isGrandmaFinished == true)
        {
            GramStatus.text = "Cat was Found!";
        }

        if (isFarmerFinished == true)
        {
            FarmStatus.text = "All Trees Planted!";
        }

        if(isMailFinished == true)
        {
            MailStatus.text = "All Mail Found!";
        }

        if (isTruckerFinished == true)
        {
            TireStatus.text = "Tire was Fixed!";
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            TaskDisplay.SetActive(true);
        }

        ///
        ///

        if(isGrandmaFinished == true && isFarmerFinished == true && isMailFinished == true && isTruckerFinished == true)
        {
            Finish.gameObject.SetActive(true);
            Close.gameObject.SetActive(false);
        }
    }

    public void Continue()
    {
        ContinueButton.gameObject.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            NarratorText.text = "";
            StartCoroutine(Talking());
        }
        else
        {
            NarratorText.text = "";
            NarratorBox.gameObject.SetActive(false);
            SceneManager.LoadScene("EndScene");
        }
    }
    public void FinishButton()
    {
        NarratorBox.gameObject.SetActive(true);
        StartCoroutine(Talking());
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
