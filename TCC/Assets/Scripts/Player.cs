using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float acceleration;
    public float decceleration;
    public float velPower;

    public float crouchSpeed;
    public bool isCrouching;

    // public float frictionAmount;

    public float jumpForce;
    public bool isJumping;
    public float jumpCutMultiplier;
    public float gravityScale;
    public float fallGravityMultipler;

    public Transform tf;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public SpriteRenderer sr;
    public Transform groundCheckPoint;
    public Vector2 groundCheckSize;
    public Transform cellingCheckPoint;
    public Vector2 cellingCheckSize;
    public LayerMask groundLayer;


    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move();

        if(Input.GetKey(KeyCode.S) || Physics2D.OverlapBox(cellingCheckPoint.position, cellingCheckSize, 0, groundLayer)){
            Crouch();
        } else {
            moveSpeed = 10;
            bc.enabled = true;
        }

        if(Input.GetButtonDown("Jump") && !isJumping){
            Jump();
            isJumping = false;
        }
        OnJumpUp();
        JumpGravity();
    }

    void Move()
    {
        // movimentação básica (sem aceleração)
        // float moveDirection = Input.GetAxis("Horizontal");
        // rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        float moveDirection = Input.GetAxis("Horizontal");
        float targetSpeed = moveDirection * moveSpeed;
        float speedDif = targetSpeed - rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        rb.AddForce(movement * Vector2.right);

        if(moveDirection > 0){
            sr.flipX = false;
        } else if(moveDirection < 0){
            sr.flipX = true;
        }
    }

    void Crouch()
    {
        moveSpeed = crouchSpeed;
        bc.enabled = false;
        
        // if(Physics2D.OverlapBox(cellingCheckPoint.position, cellingCheckSize, 0, groundLayer)){

        // }
    }

    void Jump()
    {
        if(Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer)){
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            // lastGroundedTime = 0;
            // lastJumpTime = 0;
            isJumping = true;
            // jumpInputReleased = false;
        }
    }

    void OnJumpUp()
    {
        if(rb.velocity.y > 0 && isJumping){
            rb.AddForce(Vector2.down * rb.velocity.y * (1 - jumpCutMultiplier), ForceMode2D.Impulse);
        }
    }

    void JumpGravity()
    {
        if(rb.velocity.y < 0){
            rb.gravityScale = gravityScale * fallGravityMultipler;
        } else {
            rb.gravityScale = gravityScale;
        }
    }

    // void Friction()
    // {
    //     if(lastGroundedTime > 0 && Mathf.Abs(InputHandler.instance.MoveInput) < 0.01f){
    //         float amount = Mathf.Min(Mathf.Abs(rb.velocity.x), Mathf.Abs(frictionAmount));
    //         amount *= Mathf.Sign(rb.velocity.x);
    //         rb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
    //     }
    // }
}
