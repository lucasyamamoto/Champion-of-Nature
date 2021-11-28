using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoneshield : CharacterSkill
{
    [SerializeField] private GameObject shieldPrefab;
    private GameObject shieldRight;
    private GameObject shieldLeft;
    private CharacterMovement characterMovement;
    private Animator animator;
    private InputManager.KeyStatus currentInput;

    public override InputManager.KeyStatus CurrentInput { get => currentInput; set => currentInput = value; }

    // Start is called before the first frame update
    void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
        animator = GetComponent<Animator>();
        shieldRight = Instantiate(shieldPrefab, transform.position + shieldPrefab.transform.localPosition * transform.localScale.x, shieldPrefab.transform.rotation);
        shieldRight.SetActive(false);
        shieldRight.transform.parent = this.transform;

        Vector3 leftPosition = transform.position + shieldPrefab.transform.localPosition * transform.localScale.x;
        leftPosition.y -= 2 * shieldPrefab.transform.localPosition.y;
        shieldLeft = Instantiate(shieldPrefab, leftPosition, shieldPrefab.transform.rotation);
        shieldLeft.SetActive(false);
        shieldLeft.transform.Rotate(0f, 180f, 0f);
        shieldLeft.transform.parent = this.transform;

        currentInput = new InputManager.KeyStatus();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject currentShield = (transform.rotation.eulerAngles.y == 0f) ? shieldRight : shieldLeft;
        currentShield.gameObject.SetActive(currentInput.key);
        characterMovement.Block = currentInput.key;
        animator.SetBool("Shielding", currentInput.key);
    }
}
