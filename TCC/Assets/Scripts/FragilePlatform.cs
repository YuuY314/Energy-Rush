using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    public float breakingTime;
    public float respawnTime;

    public GameObject fragile;
    public GameObject particles;

    void OnDisable()
    {
        Invoke("Respawn", respawnTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            Invoke("Break", breakingTime);
            Vector2 pos = collision.contacts[0].point;
            Instantiate(particles, pos, Quaternion.identity);
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
