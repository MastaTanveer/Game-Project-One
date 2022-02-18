using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterScript : MonoBehaviour
{
    public Animator LetterAnim;
    public Button Pickup;
    private GameObject Player;
    public bool PlayerContact;
    public bool isSignal;

    // Start is called before the first frame update
    void Start()
    {
        isSignal = false;
        Player = GameObject.Find("Player");
    }


    // Update is called once per frame
    void Update()
    {

        if (PlayerContact == true)
        {
            LetterAnim.SetBool("NearLetter", true);
            Pickup.gameObject.SetActive(true);
        }
        else if (PlayerContact == false)
        {
            LetterAnim.SetBool("NearLetter", false);
            Pickup.gameObject.SetActive(false);
        }
    }

    public void read()
    {
        Time.timeScale = 0f;
        Player.GetComponent<HubPlayer>().moveSpeed = 0;
    }

    public void putAway()
    {
        Time.timeScale = 1f;
        isSignal = true;
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
}
