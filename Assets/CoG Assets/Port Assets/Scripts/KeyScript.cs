using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public bool playerHasKey = false;
    public GameObject Barrier;
    public Sprite Unlocked;
    public AudioSource Sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHasKey = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Barrier.GetComponent<SpriteRenderer>().sprite = Unlocked;
            Sound.Play();
        }
    }
}
