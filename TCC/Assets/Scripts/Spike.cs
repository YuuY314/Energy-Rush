using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Transform checkpointArea;
    public float delay;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && Player.instance.isKnockbacked == false){
            StartCoroutine(Checkpoint(collision));
        }
    }

    IEnumerator Checkpoint(Collision2D collision)
    {
        collision.gameObject.transform.position = new Vector2(checkpointArea.position.x, checkpointArea.position.y);
        yield return new WaitForSeconds(delay);
    }
}
