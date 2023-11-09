using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatKing : MonoBehaviour
{
    public float enemySpeed;
    private bool isFacingRight = true;
    public Rigidbody2D rb;

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

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag != "Trigger" && collider.gameObject.tag != "Collectable" && collider.gameObject.tag != "Projectile"){
            enemySpeed = -enemySpeed;
            Flip();
        }
    }
}
