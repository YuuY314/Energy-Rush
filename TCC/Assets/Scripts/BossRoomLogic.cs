using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomLogic : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject bossCamera;
    public GameObject doors;
    public Enemy boss;
    public BoxCollider2D bc;
    public GameObject ratKing;
    public GameObject spawnPoint;

    void Update()
    {
        if(boss.enemyHealth <= 0){
            doors.SetActive(false);
            mainCamera.SetActive(true);
            bossCamera.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            mainCamera.SetActive(false);
            bossCamera.SetActive(true);
            doors.SetActive(true);
            bc.enabled = false;
            Invoke("Spawn", 1);
        }
    }

    void Spawn()
    {
        Instantiate(ratKing, spawnPoint.transform.position, Quaternion.identity);
    }
}
