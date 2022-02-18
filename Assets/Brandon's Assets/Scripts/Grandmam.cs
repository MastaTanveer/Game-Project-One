using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandmam : MonoBehaviour
{
    public GameObject taskM;
    public bool hasCat;
    public GameObject HappyGma;
    // Start is called before the first frame update
    void Start()
    {
        taskM = GameObject.Find("TaskManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<DialogTrigger>().inRange == true && hasCat == true)
        {
            taskM.GetComponent<Tasks_GameManager>().isGrandmaFinished = true;
            Instantiate(HappyGma, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
