using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator anim;
    public GameObject instruction;
    public GameObject go;
    private bool isOpen = false;
    
    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            if(Input.GetButtonDown("Interact") && !isOpen){
                anim.SetBool("Open", true);
                instruction.SetActive(false);
                isOpen = true;
                Invoke("Spawn", 3.5f);
            }
        }
    }

    void Spawn()
    {
        Instantiate(go, transform.position, Quaternion.identity);
    }
}
