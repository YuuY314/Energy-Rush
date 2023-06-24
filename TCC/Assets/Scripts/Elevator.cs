using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform startPoint;
    public Transform endPoint;
    public float elevatorSpeed;
    private bool isGoingUp;
    private bool isGoingDown;
    private bool isMoving;

    void FixedUpdate()
    {
        Move();
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            if(!isMoving){
                if(Input.GetKeyDown(KeyCode.E) && transform.position.y <= startPoint.position.y){
                    isGoingUp = true;
                    isMoving = true;
                } else if(Input.GetKeyDown(KeyCode.E) && transform.position.y <= endPoint.position.y){
                    isGoingDown = true;
                    isMoving = true;
                }
            }
        }
    }
    
    void Move()
    {
        if(isGoingUp){
            if(transform.position.y != endPoint.position.y){
                transform.position = Vector2.MoveTowards(transform.position, endPoint.position, elevatorSpeed * Time.deltaTime);
            } else {
                transform.position = new Vector2(endPoint.position.x, endPoint.position.y);
                isGoingUp = false;
                isMoving = false;
            }
        }
        
        if(isGoingDown){
            if(transform.position.y != startPoint.position.y){
                transform.position = Vector2.MoveTowards(transform.position, startPoint.position, elevatorSpeed * Time.deltaTime);
            } else {
                transform.position = new Vector2(startPoint.position.x, startPoint.position.y);
                isGoingDown = false;
                isMoving = false;
            }
        }
    }
}
