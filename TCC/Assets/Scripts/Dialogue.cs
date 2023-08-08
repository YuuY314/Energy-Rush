using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string actorName;
    public string[] dialogueText;

    public bool onTriggerArea = false;
    public bool haveStartedDialogue = false;

    public DialogueManager dm;

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.E) && onTriggerArea && !haveStartedDialogue){
            Interact();
            haveStartedDialogue = true;
        } else if(Input.GetKey(KeyCode.E) && onTriggerArea && haveStartedDialogue){
            dm.NextSentence();
        }
    }

    public void Interact()
    {
        dm.Dialogue(profile, actorName, dialogueText);
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
