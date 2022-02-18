using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trucker : MonoBehaviour
{
    public GameObject truck;
    public GameObject trucker2;
    private GameObject TaskM;
    // Start is called before the first frame update
    void Start()
    {
        TaskM = GameObject.Find("TaskManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (truck.GetComponent<Truck>().hasWheel == true)
        {
            Instantiate(trucker2, transform.position, Quaternion.identity);
            TaskM.GetComponent<Tasks_GameManager>().isTruckerFinished = true;
        }
    }
}
