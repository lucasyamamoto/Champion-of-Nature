using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windstep : CharacterSkill
{
    private JumpMovement jumpMovement;
    private InputManager.KeyStatus currentInput;

    public override InputManager.KeyStatus CurrentInput { get => currentInput; set => currentInput = value; }

    // Start is called before the first frame update
    void Start()
    {
        jumpMovement = GetComponent<JumpMovement>();
        currentInput = new InputManager.KeyStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInput.keyDown)
        {
            jumpMovement.DoubleJump();
        }
    }
}
