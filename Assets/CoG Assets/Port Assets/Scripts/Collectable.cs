using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private GameObject Player;
    public SpriteRenderer sr;
    public BoxCollider2D bc;
    public AudioSource CoinSound;
    public GameObject gManager;
    public float speedBuff;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        gManager = GameObject.Find("GameManager");
        Player = GameObject.Find("Player");
    }

   
    void Update()
    {
       //This is a Change
       //I see the change
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sr.enabled = false;
            bc.enabled = false;
            CoinSound.Play();
            gManager.GetComponent<GameManager>().DonutCount += 1;
            Player.GetComponent<PlayerS>().moveSpeed += speedBuff;
        }
    }
   
}
