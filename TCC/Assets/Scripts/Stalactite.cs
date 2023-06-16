using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    public float fallSpeed;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public BoxCollider2D bcTrigger;

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.mass = 100;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            rb.gravityScale = 1;
            rb.velocity = -transform.up * fallSpeed;
        }
    }
}
