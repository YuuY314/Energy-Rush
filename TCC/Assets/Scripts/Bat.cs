using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Bat : MonoBehaviour
{
    public AIPath aiPath;
    private bool isFacingRight = true;

    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f && !isFacingRight){
            Flip();
        } else if(aiPath.desiredVelocity.x <= -0.01f && isFacingRight){
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
}
