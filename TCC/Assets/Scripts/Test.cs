using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Test : MonoBehaviour
{
    public TilemapCollider2D tc;
    public float interval = 3;

    void Update()
    {
        Invoke("Interval", interval);
    }

    void Interval()
    {
        tc.enabled = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            gameObject.layer = 3;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            if(Input.GetButtonDown("Crouch")){
                tc.enabled = false;
                gameObject.layer = 6;
                Debug.Log("teste");
            }
        }
    }
}
