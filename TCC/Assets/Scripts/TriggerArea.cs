using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            if(Player.instance.isKnockbackedToTheRight){
                Player.instance.rb.velocity = new Vector2(-Player.instance.knockbackForce, Player.instance.knockbackForce * 1.5f);
            } else {
                Player.instance.rb.velocity = new Vector2(Player.instance.knockbackForce, Player.instance.knockbackForce * 1.5f);
            }
        }
    }
}
