using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSkill : CharacterSkill
{
    private InputManager.KeyStatus currentInput;
    public override InputManager.KeyStatus CurrentInput { get => currentInput; set => currentInput = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
