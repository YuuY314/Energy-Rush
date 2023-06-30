using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponNumber;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Trigger"){
            GameLogic.instance.itemSFX.Play();
            if(weaponNumber == "Weapon 01"){
                GameGlobalLogic.gIsEquippedWithWeapon1 = true;
            }
            Destroy(gameObject);
        }
    }
}
