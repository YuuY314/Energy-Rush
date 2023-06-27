using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelControl : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            if(Input.GetKeyDown(KeyCode.E)){
                if(Elevator.instance.isVertical){
                    if(Elevator.instance.transform.position.y == Elevator.instance.startPoint.position.y){
                        Elevator.instance.isGoingToStartPoint = true;
                        Elevator.instance.isMoving = true;
                    } else if(Elevator.instance.transform.position.y == Elevator.instance.endPoint.position.y){
                        Elevator.instance.isGoingToEndPoint = true;
                        Elevator.instance.isMoving = true;
                    }
                }

                if(Elevator.instance.isHorizontal){
                    if(Elevator.instance.transform.position.x == Elevator.instance.startPoint.position.x){
                        Elevator.instance.isGoingToStartPoint = true;
                        Elevator.instance.isMoving = true;
                    } else if(Elevator.instance.transform.position.x == Elevator.instance.endPoint.position.x){
                        Elevator.instance.isGoingToEndPoint = true;
                        Elevator.instance.isMoving = true;
                    }
                    Debug.Log("AlÔ");
                }
                
                Elevator.instance.Move();
            }
        }
    }
}
