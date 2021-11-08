using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquaslide : CharacterSkill
{
    private Rigidbody2D rigidBody;
    private JumpMovement jumpMovement;
    private CharacterMovement playerMovement;
    [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;
    private InputManager.KeyStatus currentInput;

    public override InputManager.KeyStatus CurrentInput { get => currentInput; set => currentInput = value; }

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
        playerMovement = GetComponent<CharacterMovement>();
        currentInput = new InputManager.KeyStatus();
    }

    // Update is called once per frame
    void Update()
    {
        // Dash
        if (currentInput.keyDown && jumpMovement.OnGround())
        {
            StartCoroutine(Dash());
        }
    }
}
