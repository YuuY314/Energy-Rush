using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Bat : MonoBehaviour
{
    private bool isVertical;
    private bool isHorizontal;

    public float enemySpeedX;
    public float enemySpeedY;
    private bool isFacingRight = true;
    public string type;
    public bool isGoingToStartPoint = true;
    public bool isGoingToEndPoint;

    public Rigidbody2D rb;

    public Transform startPoint;
    public Transform endPoint;

    void Start()
    {
        VerticalOrHorizontal(type);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if(isVertical){
            if(isGoingToStartPoint){
                if(transform.position.y != startPoint.position.y){
                    transform.position = Vector2.MoveTowards(transform.position, startPoint.position, enemySpeedY * Time.deltaTime);
                } else {
                    transform.position = new Vector2(transform.position.x, startPoint.position.y);
                    isGoingToStartPoint = false;
                    isGoingToEndPoint = true;
                }
            }

            if(isGoingToEndPoint){
                if(transform.position.y != endPoint.position.y){
                    transform.position = Vector2.MoveTowards(transform.position, endPoint.position, enemySpeedY * Time.deltaTime);
                } else {
                    transform.position = new Vector2(transform.position.x, endPoint.position.y);
                    isGoingToStartPoint = true;
                    isGoingToEndPoint = false;
                }
            }
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

    // void Flip()
    // {
    //     isFacingRight = !isFacingRight;
    //     transform.Rotate(0, 180, 0);
    // }

    // void OnTriggerExit2D(Collider2D collider)
    // {
    //     if(collider.gameObject.tag != "Trigger" && collider.gameObject.tag != "Collectable"){
    //         enemySpeedY = -enemySpeedY;
    //         Flip();
    //     }
    // }
}
