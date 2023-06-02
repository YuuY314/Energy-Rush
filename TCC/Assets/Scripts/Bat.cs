using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Bat : MonoBehaviour
{
    public float enemySpeedX;
    public float enemySpeedY;
    private bool isFacingRight = true;

    public CircleCollider2D cc;
    public Rigidbody2D rb;

    void Update()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(enemySpeedX, enemySpeedY);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag != "Trigger" && collider.gameObject.tag != "Collectable"){
            enemySpeedX = -enemySpeedX;
            enemySpeedY = -enemySpeedY;
            Flip();
        }
    }
}
