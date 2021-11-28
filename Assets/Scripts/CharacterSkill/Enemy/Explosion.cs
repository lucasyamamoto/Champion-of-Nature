using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CharacterMovement))]
public class Explosion : CharacterSkill
{
    private Animator animator;
    private CharacterMovement characterMovement;
    private CharacterHP characterHP;
    [SerializeField] private float explodingHP;
    [SerializeField] private bool destroyOnExplosion;
    [SerializeField] private int attackStage;
    private InputManager.KeyStatus currentInput;

    public override InputManager.KeyStatus CurrentInput { get => currentInput; set => currentInput = value; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        characterHP = GetComponent<CharacterHP>();
        currentInput = new InputManager.KeyStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInput.keyDown && !characterMovement.Block)
        {
            animator.SetTrigger("Attacking");
        }
        characterMovement.Block = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Contains("Attack");

        if (attackStage == 1 && characterHP.Health != explodingHP)
        {
            characterHP.Health = explodingHP;
        }
        else if (attackStage == 2)
        {
            if (destroyOnExplosion)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
