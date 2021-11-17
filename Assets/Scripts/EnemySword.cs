using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator), typeof(CharacterMovement))]
public class EnemySword : CharacterSkill
{
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private GameObject swordParent;
    private Animator animator;
    private CharacterMovement characterMovement;
    private GameObject sword;
    private InputManager.KeyStatus currentInput;
    [SerializeField] private bool showSword;

    public bool ShowSword { get => showSword; set => showSword = value; }

    public override InputManager.KeyStatus CurrentInput { get => currentInput; set => currentInput = value; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        sword = Instantiate(swordPrefab, swordParent.transform.position, swordParent.transform.rotation);
        sword.transform.parent = swordParent.transform;
        sword.transform.localPosition = swordPrefab.transform.localPosition;
        sword.transform.localRotation = swordPrefab.transform.localRotation;
        currentInput = new InputManager.KeyStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInput.keyDown)
        {
            animator.SetTrigger("Attacking");
            characterMovement.Block = true;
        }
        sword.SetActive(showSword);
        characterMovement.Block = animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Sword_Attack") ||
                                  animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Jump_Sword_Attack");
    }
}

