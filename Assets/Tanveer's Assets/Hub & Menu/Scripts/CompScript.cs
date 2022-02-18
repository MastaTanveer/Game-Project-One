using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompScript : MonoBehaviour
{
    public Animator Comp;
    public Button UseButton;
    public bool PlayerContact;

    // Start is called before the first frame update
    void Start()
    {
        PlayerContact = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerContact == true)
        {
            Comp.SetBool("NearComp", true);
            UseButton.gameObject.SetActive(true);
        }
        else if (PlayerContact == false)
        {
            Comp.SetBool("NearComp", false);
            UseButton.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerContact = false;
    }

    //Buttons
    public void useButton()
    {
        Time.timeScale = 0f;
        UseButton.interactable = false;
    }
    public void shutDown()
    {
        Time.timeScale = 1f;
        UseButton.interactable = true;
    }
}
