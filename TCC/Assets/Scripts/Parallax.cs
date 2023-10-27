using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPos;
    private Transform cam;
    public float parallaxEffect;

    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
        startPos = cam.position.x;
    }

    void Update()
    {
        float rePos = cam.transform.position.x * (1 - parallaxEffect);
        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if(rePos > startPos + length){
            startPos += length;
        } 
        
        if(rePos < startPos + length){
            startPos -= length;
        }
    }
}
