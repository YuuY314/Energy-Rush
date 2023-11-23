using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatKing : MonoBehaviour
{
    public bool isFacingRight = true;
    public Rigidbody2D rb;
    public Animator anim;
    public Enemy enemy;
    public int maxHealth;

    public static RatKing instance;

    private GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        enemy.enemyHealth = maxHealth;
    }

    void Update()
    {
        Invoke("Agro", 1);

        if(enemy.enemyHealth <= maxHealth / 2){
            anim.SetBool("Roll", true);
        } else {
            anim.SetBool("Roll", false);
        }
    }

    void Agro()
    {
        anim.SetBool("Walk", true);
    }

    public void LookAtPlayer()
    {
        if(target.transform.position.x < transform.position.x && isFacingRight){
            Flip();
        } else if(target.transform.position.x > transform.position.x && !isFacingRight){
            Flip();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            anim.SetTrigger("Attack");
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag != "Trigger" && collider.gameObject.tag != "Collectable" && collider.gameObject.tag != "Projectile"){
            RatKingRoll.instance.speed = -RatKingRoll.instance.speed;
            Flip();
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
}
