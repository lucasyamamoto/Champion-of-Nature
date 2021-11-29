using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CharacterMovement))]
public class DashAttack : CharacterSkill
{
    private Animator animator;
    private CharacterMovement characterMovement;
    private InputManager.KeyStatus currentInput;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    private bool isReady;

    public override InputManager.KeyStatus CurrentInput { get => currentInput; set => currentInput = value; }

    IEnumerator Dash()
    {
        isReady = false;
        animator.SetBool("Dashing", true);
        characterMovement.Speed += dashSpeed;

        yield return new WaitForSecondsRealtime(dashDuration);

        characterMovement.Speed -= dashSpeed;
        animator.SetBool("Dashing", false);
        isReady = true;

        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        currentInput = new InputManager.KeyStatus();
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInput.keyDown && !characterMovement.Block && isReady)
        {
            animator.SetTrigger("Attacking");
            StartCoroutine(Dash());
            isReady = false;
        }
        else
        {
            characterMovement.Block = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Attack");
        }
    }
}
