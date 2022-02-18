using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailMan : MonoBehaviour
{
    private GameObject TaskM;
    public GameObject MailManFin;
    public bool canPickupMail;
    public bool inRange;
    public static int mailCollected;

    // Start is called before the first frame update
    void Start()
    {
        TaskM = GameObject.Find("TaskManager");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("You Have " + mailCollected + " Mail");
        if(mailCollected == 5)
        {
           TaskM.GetComponent<Tasks_GameManager>().isMailFinished = true;
            Instantiate(MailManFin, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
