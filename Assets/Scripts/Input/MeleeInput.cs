using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeleeInput : InputManager
{
    [SerializeField] private float attackingDistance;
    [SerializeField] private float delay;
    private bool isReady;
    private bool preparing;

    IEnumerator PrepareAttack()
    {
        preparing = true;

        yield return new WaitForSecondsRealtime(delay);

        isReady = true;
        preparing = false;

        yield return null;
    }

    IEnumerator DisableAttack()
    {
        preparing = true;

        yield return new WaitForSecondsRealtime(0.05f);
        
        isReady = false;
        preparing = false;

        yield return null;
    }

    public override float HorizontalAxis()
    {
        if (Math.Abs(target.transform.position.x - transform.position.x) <= attackingDistance)
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
        KeyStatus attack;

        if (Math.Abs(target.transform.position.x - transform.position.x) <= attackingDistance)
        {
            if(isReady)
            {
                attack = new KeyStatus(true, true, false);
                if(!preparing)
                {
                    StartCoroutine(DisableAttack());
                }
            }
            else
            {
                if (!preparing)
                {
                    StartCoroutine(PrepareAttack());
                }
                attack = new KeyStatus();
            }
        }
        else
        {
            attack = new KeyStatus();
        }

        return attack;
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
        isReady = true;
        preparing = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
