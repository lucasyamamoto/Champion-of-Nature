using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private CharacterSkill basicAttack;
    [SerializeField] private CharacterSkill elementalSkill1;
    [SerializeField] private CharacterSkill elementalSkill2;
    [SerializeField] private GameObject bracelet1;
    [SerializeField] private GameObject bracelet2;
    private InputManager inputManager;
    private bool blockAttack;

    public bool Block { get => blockAttack; set => blockAttack = value; }

    public CharacterSkill ElementalSkill1 { get => elementalSkill1; set => elementalSkill1 = value; }
    public CharacterSkill ElementalSkill2 { get => elementalSkill2; set => elementalSkill2 = value; }

    void ActivateBracelet1()
    {
        if (bracelet1)
        {
            bracelet1.GetComponent<SpriteRenderer>().color = elementalSkill1.BraceletColor;
            bracelet1.SetActive(true);
        }
    }

    void ActivateBracelet2()
    {
        if (bracelet2)
        {
            bracelet2.GetComponent<SpriteRenderer>().color = elementalSkill2.BraceletColor;
            bracelet2.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        blockAttack = false;

        ActivateBracelet1();
        ActivateBracelet2();
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
