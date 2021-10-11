using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidBody;
    [SerializeField] private float speed;
    [SerializeField] private float zCompensation;
    [SerializeField] private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rigidBody.velocity.y, Input.GetAxis("Vertical") * zCompensation * speed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0f, rigidBody.velocity.z);
            rigidBody.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
    }
}
