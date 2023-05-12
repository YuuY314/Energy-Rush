using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public string typeGear;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            if(typeGear == "rusty"){
                GameLogic.instance.rustyGears++;
            } else if(typeGear == "normal"){
                GameLogic.instance.normalGears++;
            } else if(typeGear == "stainless"){
                GameLogic.instance.stainlessGears++;
            }
            Destroy(gameObject);
        }
    }
}
