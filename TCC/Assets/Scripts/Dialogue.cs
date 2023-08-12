using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string actorName;
    public string[] dialogueText;

    public bool onTriggerArea = false;
    public bool hasStartedDialogue = false;

    public Player player;

    public DialogueManager dm;

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.E) && onTriggerArea && !hasStartedDialogue){
            Interact();
            hasStartedDialogue = true;
        } else if(Input.GetKey(KeyCode.E) && onTriggerArea && hasStartedDialogue){
            dm.NextSentence();
        }
    }

    public void Interact()
    {
        dm.Dialogue(profile, actorName, dialogueText);
        player.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            onTriggerArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            onTriggerArea = false;
        }
    }
}
