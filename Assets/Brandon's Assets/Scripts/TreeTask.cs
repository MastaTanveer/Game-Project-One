using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTask : MonoBehaviour
{
    public bool playerInContact;
    public GameObject Farmer;
    private GameObject Player;
    public GameObject Tree;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Farmer = GameObject.Find("Farmer");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInContact == true && Input.GetKeyDown(KeyCode.Space) && Player.GetComponent<PlayerScript>().hasSeed == true)
        {
            Tree.SetActive(true);
            Farmer.GetComponent<Farmer>().TreesPlanted += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInContact = false;
    }

}
