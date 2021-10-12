using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum JumpState { OnGround, Jumping, Falling, DoubleJumping, DoubleJumpingFalling };

    private Rigidbody2D rigidBody;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float dashForce;
    private JumpState jumpState;                    // Jump state machine to avoid infinite jumps
    private bool facingRight;

    public bool FacingRight { get => facingRight; }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        jumpState = JumpState.OnGround;
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Update facing direction
        if(Input.GetAxis("Horizontal") != 0f)
        {
            facingRight = (Input.GetAxis("Horizontal") > 0f);
        }

        // Update jump state
        if (rigidBody.velocity.y > 0f)
        {
            if (jumpState == JumpState.OnGround)
            {
                jumpState = JumpState.Jumping;
            }
        }
        else if (rigidBody.velocity.y < 0f)
        {
            if (jumpState == JumpState.Jumping)
            {
                jumpState = JumpState.Falling;
            }
            else if (jumpState == JumpState.DoubleJumping)
            {
                jumpState = JumpState.DoubleJumpingFalling;
            }
        }
        else if (jumpState == JumpState.Falling || jumpState == JumpState.DoubleJumpingFalling)
        {
            jumpState = JumpState.OnGround;
        }

        // Walking movement
        rigidBody.velocity = new Vector2(
            Input.GetAxis("Horizontal") * speed, 
            rigidBody.velocity.y
        );
        
        // Jumping movement
        if (Input.GetKeyDown(KeyCode.Space) && jumpState == JumpState.OnGround)
        {
            // Reset Y velocity and re-apply jump force
            //rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0f, rigidBody.velocity.z);
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        /* For preview purposes only! Those below may change and/or be moved to a different component */
        // Basic attack (Eldritch Edge)
        transform.GetChild(1).gameObject.SetActive(Input.GetKey(KeyCode.Z));

        // Water skill (dash)
        if (Input.GetKeyDown(KeyCode.X) && jumpState == JumpState.OnGround)
        {
            rigidBody.AddForce(new Vector2(Input.GetAxis("Horizontal") * dashForce, 0f), ForceMode2D.Impulse);
        }

        // Air skill (double jump)
        if (Input.GetKeyDown(KeyCode.C) && (jumpState == JumpState.Jumping || jumpState == JumpState.Falling))
        {
            // Reset Y velocity and re-apply jump force
            jumpState = JumpState.DoubleJumping;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
