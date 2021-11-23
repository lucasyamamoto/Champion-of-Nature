using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangedInput : InputManager
{
    [SerializeField] private float attackingDistance;
    [SerializeField] private float fleeingDistance;

    public override float HorizontalAxis()
    {
        float distance = Math.Abs(target.transform.position.x - transform.position.x);

        /*if (distance <= fleeingDistance)
        {
            return (target.transform.position.x <= transform.position.x) ? 0.5f : -0.5f;
        }*/
        if (distance <= attackingDistance)
        {
            return 0f;
        }
        else
        {
            return (target.transform.position.x <= transform.position.x) ? -1f : 1f;
        }

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
        if (Math.Abs(target.transform.position.x - transform.position.x) <= attackingDistance)
        {
            return new KeyStatus(true, true, false);
        }
        else
        {
            return new KeyStatus();
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
