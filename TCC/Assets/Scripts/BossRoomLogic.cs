using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomLogic : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject bossCamera;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            mainCamera.SetActive(false);
            bossCamera.SetActive(true);
        }
    }
}
