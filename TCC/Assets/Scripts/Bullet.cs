using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();
        if(enemy != null){
            enemy.TakeDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
}
