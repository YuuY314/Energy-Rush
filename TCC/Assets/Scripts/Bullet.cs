using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    public float energyCost;
    public Rigidbody2D rb;
    public GameObject go;

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
        GameLogic.instance.battery -= energyCost;
        GameLogic.instance.UpdateBattery();
    }

    void Spawn()
    {
        Instantiate(go, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();
        if(enemy != null){
            enemy.TakeDamage(bulletDamage);
        }
        
        if(collider.gameObject.tag != "Collectable" && collider.gameObject.tag != "Trigger"){
            if(collider.gameObject.tag == "Breakable"){
                Spawn();
            }
            Destroy(gameObject);
        }
    }
}
