using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public static bool playerAlive;
    public static bool gameActive;
    Rigidbody2D rb;
    [SerializeField] public float moveSpeed;
    public float moveSpeedDefault = 5f;
    [SerializeField] int jumpPower;
    [SerializeField] float jumpTime;
     float jumpCounter;
    [SerializeField] float jumpMultiplier;
    [SerializeField] float fallMultiplier;
    [SerializeField] bool isJumping;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator anim;
    
    Vector2 vecGravity;
    private audioManager thisAudioManager;

    private void Awake()
    {
        thisAudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAlive = true;
        gameActive = true;
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            Moving();
            Jumping();
            Sliding();
        }
        else
        {
            Moving();
            winCondition();
        }
    }

  

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.8f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    void Moving()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
    void Jumping()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            anim.SetBool("Jump", true);
            jumpCounter = 0;
        }

        if (rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime) isJumping = false;

            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplier;

            if (t > 0.5f)
            {
                currentJumpM = jumpMultiplier * (1 - t);
            }
            rb.velocity += vecGravity * jumpMultiplier * Time.deltaTime;

        }

        if (Input.GetButtonUp("Jump"))
        {
            thisAudioManager.PlaySFX(thisAudioManager.jump);
            isJumping = false;
            jumpCounter = 0;
            anim.SetBool("Jump", false);
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    private void Sliding()
    {
        if (Input.GetButton("Slide") && isGrounded())
        {
           
            anim.SetBool("Slide", true);
            if (!thisAudioManager.sfxSource.isPlaying) 
            thisAudioManager.PlaySFX(thisAudioManager.slide);
        }
        else
        {
            anim.SetBool("Slide", false);
        }
    }

    private void winCondition()
    {
        if (gameActive == false)
        {
            moveSpeed -= 0.1f;
            if (moveSpeed < 0) 
            { 
                moveSpeed = 0;
                anim.SetBool("gameOver", true);
            }
        }

    }
}
