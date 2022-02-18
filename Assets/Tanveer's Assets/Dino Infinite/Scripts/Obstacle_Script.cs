using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Script : MonoBehaviour
{
    public bool gameOver;
    public float speed;
    public Rigidbody2D rb2d;
    public GameObject endlessGM;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        endlessGM = GameObject.Find("Endless Manager");
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerHit")
        {
            endlessGM.GetComponent<Endless_Manager>().isGameOver = true;
        }
    }
}
