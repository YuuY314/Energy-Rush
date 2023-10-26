using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float energyCost;
    public Transform checkpointArea;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            GameLogic.instance.battery -= energyCost;
            GameLogic.instance.UpdateBattery();
            collision.gameObject.transform.position = new Vector2(checkpointArea.position.x, checkpointArea.position.y);
            StartCoroutine(LevelTransition.instance.Transition());
        }
    }
}
