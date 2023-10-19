using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Walk")]
    public float baseSpeed;
    public float moveSpeed;
    public bool isWalking;

    private bool isFacingRight = true;

    [Header("Crouch")]
    public bool isCrouching;
    public float crouchSpeed;

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
    public Transform currentShootPoint;
    public Transform originalShootPoint;
    public Transform crouchShootPoint;
    public GameObject bulletPrefab;

    [Header("Damage")]
    public bool knockbackToTheRight;
    public float knockbackTime;
    public float knockbackTimer;
    public float knockbackForce;

    [Header("Animation")]
    public Animator anim;

    [Header("SFX")]
    public AudioSource shootSFX;
    public AudioSource jumpSFX;

    public static Player instance;

    void Start()
    {
        currentShootPoint.position = new Vector2(originalShootPoint.position.x, originalShootPoint.position.y);
        instance = this;
    }

    void Update()
    {
        isEquippedWithWeapon1 = GameGlobalLogic.gIsEquippedWithWeapon1;
        
        if(knockbackTimer <= 0){
            Move();
            knockbackTimer = knockbackTime;
        }
        Crouch();

        if(Input.GetButtonDown("Jump") && !Physics2D.OverlapBox(cellingCheckPoint.position, cellingCheckSize, 0, ceilingLayer)){
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
        CrouchShoot();
    }

    void Move()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if(Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0){
            GameLogic.instance.UpdateBattery();
            isWalking = true;
        } else {
            isWalking = false;
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
            if(IsGrounded()){
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

        if(collision.gameObject.tag == "Enemy"){
            if(knockbackTimer <= 0){
                knockbackTimer = knockbackTime;
            } else {
                if(knockbackToTheRight){
                    rb.velocity = new Vector2(-knockbackForce, knockbackForce);
                } else {
                    rb.velocity = new Vector2(knockbackForce, knockbackForce);
                }
            }

            knockbackTimer -= Time.deltaTime;
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
        Instantiate(bulletPrefab, currentShootPoint.position, currentShootPoint.rotation);
    }

    void CrouchShoot()
    {
        if(isCrouching && isShooting){
            Debug.Log("tá atirando agachado");
            currentShootPoint.position = new Vector2(crouchShootPoint.position.x, crouchShootPoint.position.y);
        } else if(!isCrouching) {
            currentShootPoint.position = new Vector2(originalShootPoint.position.x, originalShootPoint.position.y);
        }
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

        if(isCrouching && isWalking){
            anim.SetBool("Crouch Walk", true);
        } else {
            anim.SetBool("Crouch Walk", false);
        }

        if(isCrouching && isShooting){
            anim.SetBool("Crouch Shoot", true);
        } else {
            anim.SetBool("Crouch Shoot", false);
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
}
