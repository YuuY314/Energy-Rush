using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    public float fallSpeed;
    public float beforeFallTime = 0.5f;
    public Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            Invoke("Falling", beforeFallTime);
        }
    }

    void Falling()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 1;
        rb.velocity = -transform.up * fallSpeed;
    }
}
