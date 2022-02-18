using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailScript : MonoBehaviour
{
    public bool mailInRange;
    public int theScore;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mailInRange == true && Input.GetKeyDown(KeyCode.Space))
        {
            MailMan.mailCollected += 1;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mailInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        mailInRange = false;
    }
}
