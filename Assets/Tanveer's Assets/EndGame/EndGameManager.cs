using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public float typeSpeed;
    public Canvas endText;
    public TextMeshProUGUI textDisplay;
    public Button continueButton;
    private int index;
    [TextArea(3,10)]
    public string[] sentences;

    // Start is called before the first frame update
    void Start()
    {
        //[TextArea(3, 10)]
        StartCoroutine(lastCutscene());
    }

    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.gameObject.SetActive(true);
        }
    }

    IEnumerator lastCutscene()
    {
        foreach(char Letter in sentences[index].ToCharArray())
        {
            textDisplay.text += Letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void Continue()
    {
        continueButton.gameObject.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(lastCutscene());
        }
        else
        {
            textDisplay.text = "";
            endText.gameObject.SetActive(false);
        }
    }

    public void GameOne()
    {
        SceneManager.LoadScene("COGMENU");
    }
    public void GameTwo()
    {
        SceneManager.LoadScene("Endless Menu");
    }
    public void GameThree()
    {
        SceneManager.LoadScene("ReTasks");
    }
}
