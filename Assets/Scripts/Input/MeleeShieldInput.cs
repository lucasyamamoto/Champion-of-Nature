using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeleeShieldInput : InputManager
{
    [SerializeField] private float attackingDistance;
    [SerializeField] private float delay;
    [SerializeField] private float cycleDuration;
    private bool isReady;
    private bool preparing;
    private bool shielding;
    private bool canShield;

    IEnumerator UseShield()
    {
        shielding = true;

        yield return new WaitForSecondsRealtime(cycleDuration);

        shielding = false;
        canShield = false;

        yield return null;
    }

    IEnumerator UseAttack()
    {
        canShield = false;

        yield return new WaitForSecondsRealtime(cycleDuration);

        canShield = true;

        yield return null;
    }

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

        if ((Math.Abs(target.transform.position.x - transform.position.x) <= attackingDistance) && !shielding)
        {
            if (isReady)
            {
                attack = new KeyStatus(true, true, false);
                if (!preparing)
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
        return ((shielding) ? new KeyStatus(true, true, false) : new KeyStatus());
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
        shielding = false;
        canShield = false;
    }

    // Update is called once per frame
    void Update()
    {
        //print($"CanShield: {canShield} - Shielding: {shielding}");
        if (canShield && !shielding)
        {
            print("Shield");
            StartCoroutine(UseShield());
            shielding = true;
        }
        else if (!shielding)
        {
            print("Attack");
            StartCoroutine(UseAttack());
            canShield = false;
        }
    }
}
