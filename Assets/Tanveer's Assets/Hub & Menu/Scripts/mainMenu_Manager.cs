using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu_Manager : MonoBehaviour
{
    public Animator playAnim;
    public GameObject playPanel;

    public Animator optionAnim;
    public GameObject optionPanel;

    public Animator mmAnim;
    public GameObject mmPanel;

    public Animator gamesAnim;
    public GameObject gamesPanel;

    public Button Option;
    public Button Play;
    public Button Direct;
    public Button PlayClose;

    public bool isOptionOpen;
    public bool isPlayOpen;
    public bool isGamesOpen;
    public bool isAnythingOpen;


    // Start is called before the first frame update
    void Start()
    {
        optionAnim = optionPanel.GetComponent<Animator>();
        playAnim = playPanel.GetComponent<Animator>();
        mmAnim = mmPanel.GetComponent<Animator>();
        gamesAnim = gamesPanel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isOptionOpen == false && isPlayOpen == false && isGamesOpen == false)
        {
            isAnythingOpen = false;
        }
        else if(isOptionOpen == true || isPlayOpen == true || isGamesOpen == true)
        {
            isAnythingOpen = true;
        }


        if (isGamesOpen == true)
        {
            PlayClose.interactable = false;
            Option.interactable = false;
            mmAnim.SetTrigger("Closed");
        }
        else if (isGamesOpen == false)
        {
            PlayClose.interactable = true;
            mmAnim.SetTrigger("Opened");
        }
    }

    ///////////////////////////////////////////////////--Play Panel--//
    public void PlayButton()
    {
        playAnim.SetTrigger("Opened"); //Open Play Panel
        isPlayOpen = true; //Play panel is currently active
        if (isOptionOpen == true) //If option panel is open, close it
        {
            optionAnim.SetTrigger("Closed"); // close option panel
            isOptionOpen = false; // option panel is not active after pressing play
        }
        Play.interactable = false;
        Option.interactable = true;
    }
    public void ClosePlay()
    {
        playAnim.SetTrigger("Closed"); // close play panel
        isPlayOpen = false; //play panel is now inactive
        Play.interactable = true;
        Option.interactable = true;
    }
    // Inside Panel
    public void Interactive()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void directGames()
    {
        Direct.interactable = false;
        if(isPlayOpen == true)
        {
            gamesAnim.SetTrigger("Opened");
            playAnim.SetTrigger("Close2");
            isPlayOpen = false;
        }
        isGamesOpen = true;
    }
    public void gamesClose()
    {
        Direct.interactable = true;
        Option.interactable = true;
        isGamesOpen = false;
        if (isPlayOpen == false)
        {
            gamesAnim.SetTrigger("Closed");
            playAnim.SetTrigger("Opened");
            isPlayOpen = true;
        }
    }
    ///////////////////////////////////////////////////--End--//

    ///////////////////////////////////////////////////--Option Panel--//
    public void OptionButton()
    {
        optionAnim.SetTrigger("Opened"); //Open Option Panel
        isOptionOpen = true;// Option Panel is currently active
        if (isPlayOpen == true) // if play panel is open, close it
        {
            playAnim.SetTrigger("Closed");// close play panel
            isPlayOpen = false;// play panel is now inactive
            Option.interactable = true;
        }
        Option.interactable = false;
        Play.interactable = true;
    }
    public void CloseOption()
    {
        optionAnim.SetTrigger("Closed");
        isOptionOpen = false;
        Option.interactable = true;
    }
    // Exit
    public void Exit()
    {
        Application.Quit();
    }
    ///////////////////////////////////////////////////--End--//

    ///////////////////////////////////////////////////--Load Games--//
    public void LoadGameOne()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadGameTwo()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadGameThree()
    {
        SceneManager.LoadScene(7);
    }
}
