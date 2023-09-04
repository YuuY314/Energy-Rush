using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelControl : MonoBehaviour
{
    public Elevator elevator;

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            if(Input.GetButtonDown("Interact")){
                if(elevator.isVertical){
                    if(elevator.transform.position.y == elevator.startPoint.position.y){
                        elevator.isGoingToStartPoint = true;
                        elevator.isMoving = true;
                    } else if(elevator.transform.position.y == elevator.endPoint.position.y){
                        elevator.isGoingToEndPoint = true;
                        elevator.isMoving = true;
                    }
                }

                if(elevator.isHorizontal){
                    if(elevator.transform.position.x == elevator.startPoint.position.x){
                        elevator.isGoingToStartPoint = true;
                        elevator.isMoving = true;
                    } else if(elevator.transform.position.x == elevator.endPoint.position.x){
                        elevator.isGoingToEndPoint = true;
                        elevator.isMoving = true;
                    }
                }
                
                elevator.Move();
            }
        }
    }
}
