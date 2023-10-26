using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            GameLogic.instance.batterySFX.Play();
            GameLogic.instance.batteryBackup++;
            Destroy(gameObject);
        }
    }
}
