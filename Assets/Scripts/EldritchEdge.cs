using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EldritchEdge : CharacterSkill
{
    [SerializeField] private GameObject swordPrefab;
    private GameObject sword;
    private InputManager.KeyStatus currentInput;

    public override InputManager.KeyStatus CurrentInput { get => currentInput; set => currentInput = value; }

    // Start is called before the first frame update
    void Start()
    {
        sword = Instantiate(swordPrefab, transform.position + swordPrefab.transform.localPosition * transform.localScale.x, swordPrefab.transform.rotation);
        sword.transform.parent = this.transform;
        currentInput = new InputManager.KeyStatus();
    }

    // Update is called once per frame
    void Update()
    {
        // Attack
        sword.SetActive(currentInput.key);
    }
}
