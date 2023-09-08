using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float enemySpeed = 2;
    public float jumpForce = 5;
    public bool isGrounded;
    private bool isFacingRight = true;

    public Rigidbody2D rb;

    void Update()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(enemySpeed, rb.velocity.y);
        if(isGrounded){
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3){
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag != "Trigger" && collider.gameObject.tag != "Collectable" && collider.gameObject.tag != "Projectile" && collider.gameObject.layer != 3){
            enemySpeed = -enemySpeed;
            Flip();
        }
    }
}
