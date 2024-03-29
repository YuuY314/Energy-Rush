using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatKingRoll : StateMachineBehaviour
{
    public float speed;
    public float jumpForce;

    public static RatKingRoll instance;

    Transform player;
    Rigidbody2D rb;
    RatKing boss;

    public float jumpTime;
    public float jumpTimer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<RatKing>();
        if(player.position.x < boss.transform.position.x){
            speed = -speed;
        }
        instance = this;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if(jumpTimer <= 1f){
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            
            int sortTime = Random.Range(15, 60);
            int sortJump = Random.Range(10, 20);

            jumpForce = sortJump;

            jumpTime = sortTime;
            jumpTimer = jumpTime;
        }
        jumpTimer -= jumpTimer * Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
