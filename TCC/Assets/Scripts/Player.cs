using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Walk")]
    public float baseSpeed;
    public float moveSpeed;
    // public float acceleration;
    // public float decceleration;
    // public float velPower;

    private bool isFacingRight = true;

    [Header("Crouch")]
    public bool isCrouching;
    public float crouchSpeed;

    // public float frictionAmount;

    [Header("Jump")]
    public bool isJumping;
    public float jumpForce;  
    public float jumpCutMultiplier;
    public float gravityScale;
    public float fallGravityMultipler;

    [Header("Components")]
    public Transform tf;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public Transform groundCheckPoint;
    public Vector2 groundCheckSize;
    public Transform cellingCheckPoint;
    public Vector2 cellingCheckSize;
    public LayerMask groundLayer;
    public LayerMask ceilingLayer;

    [Header("Attack")]
    public bool isEquippedWithWeapon1;
    public bool isShooting;
    public Transform shootPoint;
    public GameObject bulletPrefab;

    [Header("Animation")]
    public Animator anim;

    [Header("SFX")]
    public AudioSource shootSFX;
    public AudioSource jumpSFX;

    void Update()
    {
        isEquippedWithWeapon1 = GameGlobalLogic.gIsEquippedWithWeapon1;
        
        Move();

        if((Input.GetButton("Crouch") || Physics2D.OverlapBox(cellingCheckPoint.position, cellingCheckSize, 0, ceilingLayer))){
            Crouch();
        } else {
            moveSpeed = baseSpeed;
            bc.enabled = true;
            isCrouching = false;
            anim.SetBool("Crouch", false);
        }

        if(Input.GetButtonDown("Jump") && !isJumping && !Physics2D.OverlapBox(cellingCheckPoint.position, cellingCheckSize, 0, ceilingLayer)){
            Jump();
            isJumping = false;
        }
        OnJumpUp();
        JumpGravity();

        if(Input.GetButtonDown("Fire1") && isEquippedWithWeapon1){
            shootSFX.Play();
            Shoot();
        } else {
            isShooting = false;
        }
        VerifyShootingAnimation();
    }

    void Move()
    {
        // movimentação básica (sem aceleração)
        float moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // ainda pensando se precisa mesmo de aceleração

        // float moveDirection = Input.GetAxis("Horizontal");
        // float targetSpeed = moveDirection * moveSpeed;
        // float speedDif = targetSpeed - rb.velocity.x;
        // float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        // float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        // rb.AddForce(movement * Vector2.right);

        if(moveDirection > 0 && !isFacingRight){
            Flip();
        } else if(moveDirection < 0 && isFacingRight){
            Flip();
        }
    }

    void Crouch()
    {
        isCrouching = true;
        moveSpeed = crouchSpeed;
        bc.enabled = false;
        anim.SetBool("Crouch", true);
    }

    void Jump()
    {
        if(Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer)){
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            // lastGroundedTime = 0;
            // lastJumpTime = 0;
            isJumping = true;
            anim.SetBool("Jump", true);
            jumpSFX.Play();
            // jumpInputReleased = false;
        }
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3){
            isJumping = false;
            anim.SetBool("Jump", false);
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

    void Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }

    void VerifyShootingAnimation()
    {
        if(isShooting){
            anim.SetBool("Idle Shoot", true);
        } else {
            anim.SetBool("Idle Shoot", false);
        }

        if(isJumping && isShooting){
            anim.SetBool("Jump Shoot", true);
            Debug.Log("Tá pulando atirando");
        } else {
            anim.SetBool("Jump Shoot", false);
        }

        if(isCrouching && isShooting){
            anim.SetBool("Crouch Shoot", true);
        } else {
            anim.SetBool("Crouch Shoot", false);
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

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    // void OnApplicationFocus(bool focus)
    // {
    //     if(focus){
    //         Cursor.lockState = CursorLockMode.Locked;
    //     } else {
    //         Cursor.lockState = CursorLockMode.None;
    //     }
    // // }

    // static void OnBeforeSplashScreen()
    // {
    //     Cursor.lockState = CursorLockMode.Locked;
    //     Cursor.visible = false;
    // }
}
