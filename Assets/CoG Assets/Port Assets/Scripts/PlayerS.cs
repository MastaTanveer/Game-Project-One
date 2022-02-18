using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour
{
    //GameObject Ref
    public GameObject Spawn;
    public GameObject GM;
    public GameObject checkPoint;

    //Component Ref
    public Rigidbody2D rb;
    public Animator PlayerAnim;

    //Numbers
    public float moveSpeed;
    public int Score;

    //Bools and Others
    Vector2 movement;
    public bool hasKey;

    //Story System

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerAnim = GetComponent<Animator>();
        GM = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Animations
        PlayerAnim.SetFloat("Horizontal", movement.x);
        PlayerAnim.SetFloat("Vertical", movement.y);
        PlayerAnim.SetFloat("Speed", movement.sqrMagnitude);
    }
    // Update is called X per frame
    private void FixedUpdate()
    {
        //Movement Speed
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    //Collisions 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LockedBarrier")
        {
            GetComponent<AudioSource>().Play();
            gameObject.transform.position = Spawn.transform.position;
            GM.GetComponent<GameManager>().deathCount += 1;
            PlayerAnim.SetTrigger("Death");
        }

        if (collision.gameObject.tag == "Enemy")
        {
            GetComponent<AudioSource>().Play();
            gameObject.transform.position = Spawn.transform.position;
            GM.GetComponent<GameManager>().deathCount += 1;
            PlayerAnim.SetTrigger("Death");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Check Point")
        {
            checkPoint.GetComponent<SpriteRenderer>().color = Color.green;
            Spawn.transform.position = checkPoint.transform.position;
        }
    }
}
