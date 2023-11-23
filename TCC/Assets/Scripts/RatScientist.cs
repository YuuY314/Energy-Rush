using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatScientist : MonoBehaviour
{
    private bool hasDialogue;
    private Dialogue di;

    void Start()
    {
        di = GetComponent<Dialogue>();
    }

    void Update()
    {
        hasDialogue = DialogueManager.hasDialogue;
        if(!hasDialogue)
        {
            GameGlobalLogic.gIsEquippedWithDoubleJump = true;
        }
    }
}
