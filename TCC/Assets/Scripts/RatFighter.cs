using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatFighter : MonoBehaviour
{
    public float enemySpeed;
    // public GameObject target;
    private bool isFacingRight = true;
    public Rigidbody2D rb;
    public Animator anim;

    [Header("Attack")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;

    void Update()
    {
        // if(target == null)
        //     return;
        Move();
        // if(isChasing){
        //     Chase();
        // }
    }

    void Move()
    {
        rb.velocity = new Vector2(enemySpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collsion)
    {
        if(collsion.gameObject.tag == "Player"){
            anim.SetTrigger("Attack");
        }
    }
    
    // void Chase()
    // {
    //     if(transform.position.x > target.transform.position.x && isFacingRight){
    //         Flip();
    //     } else if(transform.position.x < target.transform.position.x && !isFacingRight){
    //         Flip();
    //     }
    //     transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
    // }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag != "Trigger" && collider.gameObject.tag != "Collectable" && collider.gameObject.tag != "Projectile"){
            enemySpeed = -enemySpeed;
            Flip();
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
}
