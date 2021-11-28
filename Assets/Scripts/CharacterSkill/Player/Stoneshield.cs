using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoneshield : CharacterSkill
{
    [SerializeField] private GameObject shieldPrefab;
    private GameObject shield;
    private CharacterMovement characterMovement;
    private Animator animator;
    private InputManager.KeyStatus currentInput;

    public override InputManager.KeyStatus CurrentInput { get => currentInput; set => currentInput = value; }

    // Start is called before the first frame update
    void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
        animator = GetComponent<Animator>();
        shield = Instantiate(shieldPrefab, transform.position + shieldPrefab.transform.localPosition * transform.localScale.x, shieldPrefab.transform.rotation);
        shield.transform.parent = this.transform;
        currentInput = new InputManager.KeyStatus();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shield.gameObject.SetActive(currentInput.key);
        characterMovement.Block = currentInput.key;
        animator.SetBool("Shielding", currentInput.key);
    }
}
