using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public GameObject shopScreen;

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            if(Input.GetKeyDown(KeyCode.E)){
                Time.timeScale = 0;
                shopScreen.SetActive(true);
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        shopScreen.SetActive(false);
    }
}
