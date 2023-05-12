using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelToGo : MonoBehaviour
{
    public string levelToGo;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            GameLogic.instance.LoadLevel(levelToGo);
        }
    }
}
