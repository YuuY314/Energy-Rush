using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator anim;
    public GameObject instruction;
    
    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            if(Input.GetButtonDown("Interact")){
                anim.SetBool("Open", true);
                instruction.SetActive(false);
            }
        }
    }
}
