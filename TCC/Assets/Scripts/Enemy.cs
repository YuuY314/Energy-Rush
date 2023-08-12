using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;

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
}
