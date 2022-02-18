using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HubManager : MonoBehaviour
{
    private GameObject Envelope;
    private GameObject LetterOb;
    private GameObject Player;
    public float typeSpeed;
    //CutScene 1
    public Canvas storyOne;
    public TextMeshProUGUI storyDisplay;
    public Button next;
    private int index;
    [TextArea(3,10)]
    public string[] sentences;

    //CutScene 2
    public Canvas storyTwo;
    public TextMeshProUGUI storyDisplayTwo;
    public Button nextTwo;
    private int indexTwo;
    [TextArea(3,10)]
    public string[] sentencesTwo;
    
    public void Start()
    {
        StartCoroutine(Typing());
        LetterOb = GameObject.Find("Mail");
        Player = GameObject.Find("Player");
        Player.GetComponent<HubPlayer>().moveSpeed = 0f;
        Envelope = GameObject.Find("Mail");
    }

    public void Update()
    {
        if(storyDisplay.text == sentences[index])
        {
            next.gameObject.SetActive(true);
        }

        if(storyDisplayTwo.text == sentencesTwo[indexTwo])
        {
            nextTwo.gameObject.SetActive(true);
        }

        if(LetterOb.GetComponent<LetterScript>().isSignal == true)
        {
            storyTwo.gameObject.SetActive(true);
            StartCoroutine(TypingTwo());
            LetterOb.GetComponent<LetterScript>().isSignal = false;
        }
    }

    IEnumerator Typing()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            storyDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    IEnumerator TypingTwo()
    {
        foreach(char letterTwo in sentencesTwo[indexTwo])
        {
            storyDisplayTwo.text += letterTwo;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    //Buttons
    public void TempBack()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOne()
    {
        SceneManager.LoadScene("COGMENU");
        Time.timeScale = 1f;
    }
    public void GameTwo()
    {
        SceneManager.LoadScene("Endless Menu");
        Time.timeScale = 1f;
    }
    public void GameThree()
    {
        SceneManager.LoadScene("ReTasks");
        Time.timeScale = 1f;
    }
    //NextSentence

    public void Continue()
    {
        next.gameObject.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            storyDisplay.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            storyDisplay.text = "";
            storyOne.gameObject.SetActive(false);
            Player.GetComponent<HubPlayer>().moveSpeed = 3;
        }
    }
    public void ContinueTwo()
    {
        nextTwo.gameObject.SetActive(false);

        if (indexTwo < sentencesTwo.Length - 1)
        {
            indexTwo++;
            storyDisplayTwo.text = "";
            StartCoroutine(TypingTwo());
        }
        else
        {
            storyDisplayTwo.text = "";
            storyTwo.gameObject.SetActive(false);
            Player.GetComponent<HubPlayer>().moveSpeed = 3;
            Envelope.SetActive(false);
            Envelope.GetComponent<LetterScript>().Pickup.gameObject.SetActive(false);

        }
    }
    public void Skip()
    {
        Player.GetComponent<HubPlayer>().moveSpeed = 3;

    }
    public void SkipTwo()
    {
        Envelope.SetActive(false);
        Envelope.GetComponent<LetterScript>().Pickup.gameObject.SetActive(false);
    }
}
