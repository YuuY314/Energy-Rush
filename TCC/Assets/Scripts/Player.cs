using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Walk")]
    public float baseSpeed;
    public float moveSpeed;
    public bool isWalking = false;

    private bool isFacingRight = true;

    [Header("Crouch")]
    public bool isCrouching;
    public float crouchSpeed;

    // public float frictionAmount;

    [Header("Jump")]
    public bool isJumping;
    public float jumpForce;
    [SerializeField] private float coyoteTime = 0.5f;
    [SerializeField] private float coyoteTimeCounter;
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
        Crouch();

        if(Input.GetButtonDown("Jump")){
            Jump();
            isJumping = false;
        }

        if(IsGrounded()){
            coyoteTimeCounter = coyoteTime;
        } else {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(Input.GetButtonUp("Jump")){
            coyoteTimeCounter = 0f;
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
        float moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if(Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0){
            GameLogic.instance.UpdateBattery();
        }

        if(moveDirection > 0 && !isFacingRight){
            Flip();
        } else if(moveDirection < 0 && isFacingRight){
            Flip();
        }

        if(Input.GetAxis("Horizontal") == 0){
            anim.SetBool("Walk", false);
        } else {
            anim.SetBool("Walk", true);
        }
    }

    void Crouch()
    {
        if((Input.GetButton("Crouch") || Physics2D.OverlapBox(cellingCheckPoint.position, cellingCheckSize, 0, ceilingLayer))){
            isCrouching = true;
            moveSpeed = crouchSpeed;
            bc.enabled = false;
            anim.SetBool("Crouch", true);
        } else {
            moveSpeed = baseSpeed;
            bc.enabled = true;
            isCrouching = false;
            anim.SetBool("Crouch", false);
        }
    }

    void Jump()
    {
        if(coyoteTimeCounter > 0f){
            if(Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer)){
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            } else {
                rb.AddForce(Vector2.up * (jumpForce+0.5f), ForceMode2D.Impulse);
            }
            
            isJumping = true;
            anim.SetBool("Jump", true);
            jumpSFX.Play();
        }
    }

    bool IsGrounded()
    {
        if(Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer)){
            return true;
        } else {
            return false;
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
