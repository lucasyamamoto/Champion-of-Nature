using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossInput : InputManager
{
    [SerializeField] private float attackingDistance;
    [SerializeField] private float delay;
    private bool isReady;

    IEnumerator Cooldown()
    {
        isReady = false;

        yield return new WaitForSecondsRealtime(delay);

        isReady = true;

        yield return null;
    }

    public override float HorizontalAxis()
    {
        return 0f;
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
        if (Math.Abs(target.transform.position.x - transform.position.x) <= attackingDistance && isReady)
        {
            StartCoroutine(Cooldown());
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
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
