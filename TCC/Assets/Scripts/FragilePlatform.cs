using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    public float breakingTime = 1.2f;
    public float respawnTime = 1;

    public GameObject fragile;

    void OnDisable()
    {
        Invoke("Respawn", respawnTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            Invoke("Break", breakingTime);
        }
    }

    void Break()
    {
        fragile.SetActive(false);
    }

    void Respawn()
    {
        fragile.SetActive(true);
    }
}
