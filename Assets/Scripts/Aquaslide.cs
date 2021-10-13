using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquaslide : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private JumpMovement jumpMovement;
    private PlayerMovement playerMovement;
    [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;

    IEnumerator Dash()
    {
        playerMovement.Speed += dashForce;

        yield return new WaitForSecondsRealtime(dashDuration);

        playerMovement.Speed -= dashForce;

        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        jumpMovement = GetComponent<JumpMovement>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Dash
        if (Input.GetKeyDown(KeyCode.X) && jumpMovement.OnGround())
        {
            print("Dash" + (Input.GetAxis("Horizontal") * dashForce));
            StartCoroutine(Dash());
        }
    }
}
