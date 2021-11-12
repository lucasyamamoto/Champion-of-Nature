using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputManager))]
public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private InputManager inputManager;
    private JumpMovement jumpMovement;
    [SerializeField] private float speed;
    private bool facingRight;
    private bool blockMovement;

    public float Speed { get => speed; set => speed = value; }
    public bool FacingRight { get => facingRight; }
    
    public bool Block
    {
        get => blockMovement;
        set
        {
            blockMovement = value;
            if(blockMovement)
            {
                rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        inputManager = GetComponent<InputManager>();
        jumpMovement = GetComponent<JumpMovement>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!blockMovement)
        { 
            // Update facing direction
            if (inputManager.HorizontalAxis() != 0f)
            {
                facingRight = (inputManager.HorizontalAxis() > 0f);
                transform.rotation = Quaternion.Euler(0f, (facingRight) ? 0f : 180f, 0f);
            }

            // Walking movement
            rigidBody.velocity = new Vector2(
                inputManager.HorizontalAxis() * speed, 
                rigidBody.velocity.y
            );

            if (inputManager.Jump().keyDown && jumpMovement)
            {
                jumpMovement.Jump();
            }
        }
    }
}
