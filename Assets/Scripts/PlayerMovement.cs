using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;
    public KeyCode jump;
    public KeyCode jumpalt;
    public KeyCode jumpalt2;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        // GameManager.Instance.GameManagerCheck();
    }


    private void playAnimation(string animationTriggerName)
    {
        animator.SetTrigger(animationTriggerName);
    }
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if (input < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isMoving", true);
        }
        else if (input > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isMoving", true);
        }
        else animator.SetBool("isMoving", false);

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);
        
        if(isGrounded == false)animator.SetBool("onGround", false);
        else animator.SetBool("onGround", true);

        if ((Input.GetKey(jump) || Input.GetKey(jumpalt) || Input.GetKey(jumpalt2)) && isGrounded == true)
        {
            playerRb.linearVelocity = Vector2.up * jumpForce;
        }

    }

    void FixedUpdate()
    {
        playerRb.linearVelocity = new Vector2(input * speed, playerRb.linearVelocity.y);

    }
}