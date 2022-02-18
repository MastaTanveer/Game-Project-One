using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public bool hasWheel;
    public Sprite truckFixed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wheel")
        {
            hasWheel = true;
            GetComponent<SpriteRenderer>().sprite = truckFixed;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wheel")
        {
            hasWheel = true;
        }
    }
}
