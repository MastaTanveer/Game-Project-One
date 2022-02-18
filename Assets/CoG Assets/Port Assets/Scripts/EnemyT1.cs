using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyT1 : MonoBehaviour
{
    public Vector3 Left;
    public Vector3 Right;
    public bool goingLeft;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goingLeft == true)
        {
            rb.velocity = Left;
            //rb.AddForce(Left);
        }
        else if (goingLeft == false)
        {
            rb.velocity = Right;
            //rb.AddForce(Right);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            goingLeft = !goingLeft;
            //GetComponent<SpriteRenderer>().flipX = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            goingLeft = !goingLeft;
            //GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
