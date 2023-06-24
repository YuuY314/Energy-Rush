using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private bool isVertical;
    private bool isHorizontal;

    public float elevatorSpeed;
    public string type;

    public Rigidbody2D rb;

    public Transform startPoint;
    public Transform endPoint;
    
    public bool isGoingToStartPoint;
    public bool isGoingToEndPoint;
    private bool isMoving;

    public BoxCollider2D instructionBC;

    void Start()
    {
        VerticalOrHorizontal(type);
    }

    void FixedUpdate()
    {
        Move();
        HideInstruction();

        Debug.Log(transform.position.x <= endPoint.position.x);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            if(!isMoving){
                if(isVertical){
                    if(Input.GetKeyDown(KeyCode.E) && transform.position.y == startPoint.position.y){
                        isGoingToStartPoint = true;
                        isMoving = true;
                    } else if(Input.GetKeyDown(KeyCode.E) && transform.position.y == endPoint.position.y){
                        isGoingToEndPoint = true;
                        isMoving = true;
                    }
                }

                if(isHorizontal){
                    if(Input.GetKeyDown(KeyCode.E) && transform.position.x == startPoint.position.x){
                        isGoingToStartPoint = true;
                        isMoving = true;
                    } else if(Input.GetKeyDown(KeyCode.E) && transform.position.x == endPoint.position.x){
                        isGoingToEndPoint = true;
                        isMoving = true;
                    }
                }
            }
        }
    }
    
    void Move()
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
}
