using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EldritchEdge : CharacterSkill
{
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private GameObject swordParent;
    private Animator animator;
    private GameObject sword;
    private InputManager.KeyStatus currentInput;
    [SerializeField] private bool showSword;

    public bool ShowSword { get => showSword; set => showSword = value; }

    public override InputManager.KeyStatus CurrentInput { get => currentInput; set => currentInput = value; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        }
        sword.SetActive(showSword);
    }
}
