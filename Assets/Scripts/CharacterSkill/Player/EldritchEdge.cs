using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CharacterMovement))]
public class EldritchEdge : CharacterSkill
{

    private Animator animator;
    private CharacterMovement characterMovement;
    private InputManager.KeyStatus currentInput;

    public override InputManager.KeyStatus CurrentInput { get => currentInput; set => currentInput = value; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        currentInput = new InputManager.KeyStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInput.keyDown)
        {
            animator.SetTrigger("Attacking");
        }
        // characterMovement.Block = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Sword_Attack");
    }
}
