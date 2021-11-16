using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindlessWalkingInput : InputManager
{
    public override float HorizontalAxis()
    {
        return (target.transform.position.x <= transform.position.x) ? -1f : 1f;
    }

    public override float VerticalAxis()
    {
        return 0f;
    }

    public override KeyStatus Jump()
    {
        return new KeyStatus();
    }

    public override KeyStatus Attack()
    {
        return new KeyStatus();
    }

    public override KeyStatus ElementalSkill1()
    {
        return new KeyStatus();
    }

    public override KeyStatus ElementalSkill2()
    {
        return new KeyStatus();
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
