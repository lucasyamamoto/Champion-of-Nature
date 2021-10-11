using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidBody;
    [SerializeField] private float speed;
    [SerializeField] private float zCompensation;   // Speed compensation on z-axis for camera angle
    [SerializeField] private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Walking movement
        rigidBody.velocity = new Vector3(
            Input.GetAxis("Horizontal") * speed, 
            rigidBody.velocity.y, 
            Input.GetAxis("Vertical") * speed * zCompensation
        );
        
        // Jumping movement
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Reset Y velocity and re-apply jump force
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0f, rigidBody.velocity.z);
            rigidBody.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
    }
}
