using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endless_PlayerScript : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float jumpForce;
    public float fallForce;
    private float moveInput;

    private int jumpLimit;
    public int jumpTimes;
    
    public bool isGrounded;

    public Animator anim;
    
    public Transform feetPos;
    public Rigidbody2D rb2d;
    public LayerMask RegGround;
    //public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
    }

    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, RegGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jumped");
            jumpLimit = jumpTimes;
            rb2d.velocity = Vector2.up * jumpForce;

        } else if(Input.GetKeyDown(KeyCode.Space) && jumpLimit > 0)
        {
            anim.SetTrigger("Jumped");
            rb2d.velocity = Vector2.up * jumpForce;
            jumpLimit--;

        } else if(Input.GetKeyDown(KeyCode.Space) && jumpLimit == 0 && isGrounded == true)
        {
            rb2d.velocity = Vector2.up * jumpForce;

        } else if (isGrounded == false)
        {
            anim.SetBool("isGrounded", false);
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb2d.velocity = Vector2.down * fallForce;
            }
        } else if(isGrounded == true)
        {
            anim.SetBool("isGrounded", true);
        }
    }
}
