using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private CharacterSkill basicAttack;
    [SerializeField] private CharacterSkill elementalSkill1;
    [SerializeField] private CharacterSkill elementalSkill2;
    private InputManager inputManager;
    private bool blockAttack;

    public bool Block { get => blockAttack; set => blockAttack = value; }

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        blockAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!blockAttack)
        {
            if (inputManager.Attack().key)
            {
            
                basicAttack.CurrentInput = inputManager.Attack();
                elementalSkill1.CurrentInput = new InputManager.KeyStatus();
                elementalSkill2.CurrentInput = new InputManager.KeyStatus();
            }
            else if (inputManager.ElementalSkill1().key)
            {
            
                basicAttack.CurrentInput = new InputManager.KeyStatus();
                elementalSkill1.CurrentInput = inputManager.ElementalSkill1();
                elementalSkill2.CurrentInput = new InputManager.KeyStatus();
            }
            else
            {
            
                basicAttack.CurrentInput = new InputManager.KeyStatus();
                elementalSkill1.CurrentInput = new InputManager.KeyStatus();
                elementalSkill2.CurrentInput = inputManager.ElementalSkill2();
            }
        }
        else 
        {
            basicAttack.CurrentInput = new InputManager.KeyStatus();
            elementalSkill1.CurrentInput = new InputManager.KeyStatus();
            elementalSkill2.CurrentInput = new InputManager.KeyStatus();
        }
    }
}
