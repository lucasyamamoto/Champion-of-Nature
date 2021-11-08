using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : InputManager
{
    public override float HorizontalAxis()
    {
        return Input.GetAxis("Horizontal");
    }

    public override float VerticalAxis()
    {
        return Input.GetAxis("Vertical");
    }

    public override KeyStatus Jump()
    {
        return new KeyStatus("Jump");
    }

    public override KeyStatus Attack()
    {
        return new KeyStatus("Fire1");
    }

    public override KeyStatus ElementalSkill1()
    {
        return new KeyStatus("Fire2");
    }

    public override KeyStatus ElementalSkill2()
    {
        return new KeyStatus("Fire3");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
