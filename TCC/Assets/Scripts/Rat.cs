using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public float enemySpeed;
    private bool isFacingRight = true;

    public BoxCollider2D bc;
    public Rigidbody2D rb;
    public Transform headPoint;

    void Update()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(enemySpeed, rb.velocity.y);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            float height = collision.contacts[0].point.y - headPoint.position.y;

            if(height > 0){
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8.5f, ForceMode2D.Impulse);
                Destroy(gameObject);
            } else {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 8.5f, ForceMode2D.Impulse);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag != "Trigger" && collider.gameObject.tag != "Collectable"){
            enemySpeed = -enemySpeed;
            Flip();
        }
    }
}
