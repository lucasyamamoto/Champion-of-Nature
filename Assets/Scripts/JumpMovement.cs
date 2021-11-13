using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpMovement : MonoBehaviour
{
    public enum JumpState { OnGround, Jumping, Falling, DoubleJumping, DoubleJumpingFalling };

    [SerializeField] private float jumpForce;
    private JumpState jumpState;
    private Rigidbody2D rigidBody;

    public bool OnGround()
    {
        return jumpState == JumpState.OnGround;
    }

    public void Jump()
    {
        // Jumping movement
        if (jumpState == JumpState.OnGround)
        {
            // Apply jump force
            jumpState = JumpState.Jumping;
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void DoubleJump()
    {
        // Double jump movement
        if (jumpState == JumpState.Jumping || jumpState == JumpState.Falling)
        {
            // Reset Y velocity and re-apply jump force
            jumpState = JumpState.DoubleJumping;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpState = JumpState.OnGround;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidBody.velocity.y < 0f)
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
        else if (rigidBody.velocity.y == 0 && (jumpState == JumpState.Falling || jumpState == JumpState.DoubleJumpingFalling))
        {
            jumpState = JumpState.OnGround;
        }
    }
}
