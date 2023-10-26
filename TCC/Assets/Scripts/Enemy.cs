using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    public float enemyDamage;

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        if(enemyHealth <= 0){
            if(gameObject.tag == "Breakable"){
                GameLogic.instance.wallDestructionSFX.Play();
            }
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && gameObject.tag == "Enemy"){
            if(collision.transform.position.x <= transform.position.x){
                Player.instance.isKnockbackedToTheRight = true;
            } else if(collision.transform.position.x > transform.position.x){
                Player.instance.isKnockbackedToTheRight = false;
            }
            Player.instance.isKnockbacked = true;
            GameLogic.instance.battery -= enemyDamage;
            GameLogic.instance.UpdateBattery();
        }
    }
}
