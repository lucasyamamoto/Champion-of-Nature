using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangedInput : InputManager
{
    public override float HorizontalAxis()
    {
        if (Math.Abs(target.transform.position.x - transform.position.x) <= 9)
            return 0f;
        else
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
        if (Math.Abs(target.transform.position.x - transform.position.x) <= 9)
        {
            
            return new KeyStatus(true, true, false);
            
        }

        else
        {
         
            return new KeyStatus(false, false, false);
        }
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
