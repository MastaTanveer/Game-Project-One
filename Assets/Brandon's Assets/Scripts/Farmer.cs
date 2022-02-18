using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Farmer : MonoBehaviour
{
    private GameObject TaskM;
    public bool inRange;
    public int TreesPlanted;
    public GameObject FarmerFin;
    private GameObject Player;

    private void Start()
    {
        TreesPlanted = 0;
        TaskM = GameObject.Find("TaskManager");
        Player = GameObject.Find("Player");
    }
    private void Update()
    {

        if(inRange == true && Input.GetKeyDown(KeyCode.Space))
        {
            Player.GetComponent<PlayerScript>().hasSeed = true;
            Debug.Log("BOOL IS ACTIVE");
        }

        if (TreesPlanted == 3)
        {
            TaskM.GetComponent<Tasks_GameManager>().isFarmerFinished = true;
            Instantiate(FarmerFin, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }
}
