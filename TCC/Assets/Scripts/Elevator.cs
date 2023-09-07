using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public static Elevator instance;

    public bool isVertical;
    public bool isHorizontal;

    public float elevatorSpeed;
    public string type;

    public Rigidbody2D rb;

    public Transform startPoint;
    public Transform endPoint;
    
    public bool isGoingToStartPoint;
    public bool isGoingToEndPoint;
    public bool isMoving;

    public BoxCollider2D instructionBC;

    void Start()
    {
        VerticalOrHorizontal(type);
        instance = this;
    }

    void FixedUpdate()
    {
        Move();
        HideInstruction();
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            if(!isMoving){
                if(isVertical){
                    if(Input.GetButtonDown("Interact") && transform.position.y == startPoint.position.y){
                        isGoingToStartPoint = true;
                        isMoving = true;
                    } else if(Input.GetButtonDown("Interact") && transform.position.y == endPoint.position.y){
                        isGoingToEndPoint = true;
                        isMoving = true;
                    }
                }

                if(isHorizontal){
                    if(Input.GetButtonDown("Interact") && transform.position.x == startPoint.position.x){
                        isGoingToStartPoint = true;
                        isMoving = true;
                    } else if(Input.GetButtonDown("Interact") && transform.position.x == endPoint.position.x){
                        isGoingToEndPoint = true;
                        isMoving = true;
                    }
                }
            }
        }
    }
    
    public void Move()
    {
        if(isVertical){
            if(isGoingToStartPoint){
                if(transform.position.y != endPoint.position.y){
                    transform.position = Vector2.MoveTowards(transform.position, endPoint.position, elevatorSpeed * Time.deltaTime);
                } else {
                    transform.position = new Vector2(endPoint.position.x, endPoint.position.y);
                    isGoingToStartPoint = false;
                    isMoving = false;
                }
            }
            
            if(isGoingToEndPoint){
                if(transform.position.y != startPoint.position.y){
                    transform.position = Vector2.MoveTowards(transform.position, startPoint.position, elevatorSpeed * Time.deltaTime);
                } else {
                    transform.position = new Vector2(startPoint.position.x, startPoint.position.y);
                    isGoingToEndPoint = false;
                    isMoving = false;
                }
            }
        }

        if(isHorizontal){
            if(isGoingToStartPoint){
                if(transform.position.x != endPoint.position.x){
                    transform.position = Vector2.MoveTowards(transform.position, endPoint.position, elevatorSpeed * Time.deltaTime);
                } else {
                    transform.position = new Vector2(endPoint.position.x, endPoint.position.y);
                    isGoingToStartPoint = false;
                    isMoving = false;
                }
            }
            
            if(isGoingToEndPoint){
                if(transform.position.x != startPoint.position.x){
                    transform.position = Vector2.MoveTowards(transform.position, startPoint.position, elevatorSpeed * Time.deltaTime);
                } else {
                    transform.position = new Vector2(startPoint.position.x, startPoint.position.y);
                    isGoingToEndPoint = false;
                    isMoving = false;
                }
            }
        }
    }

    void HideInstruction()
    {
        if(isMoving){
            instructionBC.enabled = false;
        } else {
            instructionBC.enabled = true;
        }
    }

    void VerticalOrHorizontal(string type)
    {
        if(type == "Vertical"){
            isVertical = true;
        } else if(type == "Horizontal"){
            isHorizontal = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.transform.SetParent(null);
        }
    }
}
