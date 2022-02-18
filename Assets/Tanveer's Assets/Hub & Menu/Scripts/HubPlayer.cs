using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPlayer : MonoBehaviour
{
    public Animator HubAnim;
    public Rigidbody2D RB;
    public float moveSpeed;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //Animations
        HubAnim.SetFloat("Horizontal", movement.x);
        HubAnim.SetFloat("Vertical", movement.y);
        HubAnim.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        RB.MovePosition(RB.position + movement * moveSpeed * Time.deltaTime);
    }
}
