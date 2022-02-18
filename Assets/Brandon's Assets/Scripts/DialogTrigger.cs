using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    private GameObject poopyPlayer;
    public bool inRange;

    private void Start()
    {
        poopyPlayer = GameObject.Find("Player");
    }

    private void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.Space))
        {
            TriggerDialog();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
        poopyPlayer.GetComponent<PlayerScript>().moveSpeed = 0;
    }
}
