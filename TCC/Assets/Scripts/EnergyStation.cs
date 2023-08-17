using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyStation : MonoBehaviour
{
    public AudioSource rechargeSFX;

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            if(Input.GetButtonDown("Interact")){
                GameLogic.instance.battery = GameLogic.instance.batteryLimit;
                rechargeSFX.Play();
            }
        }
    }
}