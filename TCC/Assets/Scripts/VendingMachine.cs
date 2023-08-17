using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public GameObject shopScreen;

    public Player player;

    private bool hasDialogue;

    void Update()
    {
        hasDialogue = DialogueManager.hasDialogue;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            if(Input.GetButtonDown("Interact") && !hasDialogue){
                Time.timeScale = 0;
                shopScreen.SetActive(true);
                player.enabled = false;
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        shopScreen.SetActive(false);
        player.enabled = true;
    }
}
