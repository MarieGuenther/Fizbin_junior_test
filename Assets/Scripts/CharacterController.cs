using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float characterWalkSpeed = 1f;
    [SerializeField]
    private float characterRunSpeed = 2f;
    [SerializeField]
    private float characterJumpForce = 1f;
    private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;

    [SerializeField]
    private Rigidbody2D characterRigidbody;
    [SerializeField]
    private GroundCheck groundCheck;
    [SerializeField]
    private SpriteRenderer characterSprite;

    private float xMove = 0;
    private bool isRunning = false;
    private bool isGrounded = false;

    private void FixedUpdate()
    {
        //horizontal Movement check
        xMove = Input.GetAxis("Horizontal");
        MoveCharacterHorizontically();

        //jump check
        isGrounded = groundCheck.IsGrounded();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        //running check
        if (Input.GetButtonUp("Run"))
        {
            isRunning = false;
        } 
        if (isGrounded && Input.GetButtonDown("Run")) 
        {
            isRunning = true;
        }
    }

    private void MoveCharacterHorizontically()
    {
        FlipSprite();

        float characterSpeed = characterWalkSpeed;
        if (isRunning) //check if running speed is needed
        {
            characterSpeed = characterRunSpeed;
        }

        Vector3 velocityVector = new Vector3(xMove * characterSpeed, characterRigidbody.velocity.y, 0); //create velocity vector
        characterRigidbody.velocity = Vector3.SmoothDamp(characterRigidbody.velocity, velocityVector, ref m_Velocity, m_MovementSmoothing); //apply speed
    }

    private void FlipSprite()
    {
        //sprite flip
        if (xMove < 0)
        {
            characterSprite.flipX = true;
        }
        else if (xMove > 0)
        {
            characterSprite.flipX = false;
        }
    }

    private void Jump()
    {
        //only jump if grounded
        if (isGrounded)
        {
            characterRigidbody.AddForce(new Vector2(0f, characterJumpForce)); //apply jump force
        }      
    }
}
