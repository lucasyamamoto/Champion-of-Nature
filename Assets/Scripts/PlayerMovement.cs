using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private JumpMovement jumpMovement;
    [SerializeField] private float speed;
    private bool facingRight;

    public bool FacingRight { get => facingRight; }

    public float Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        jumpMovement = GetComponent<JumpMovement>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Update facing direction
        if (Input.GetAxis("Horizontal") != 0f)
        {
            facingRight = (Input.GetAxis("Horizontal") > 0f);
        }

        // Walking movement
        rigidBody.velocity = new Vector2(
            Input.GetAxis("Horizontal") * speed, 
            rigidBody.velocity.y
        );

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpMovement.Jump();
        }
    }
}
