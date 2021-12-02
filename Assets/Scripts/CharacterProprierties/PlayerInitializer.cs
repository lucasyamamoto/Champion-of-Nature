using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    [SerializeField] private PlayerSkills playerSkills;
    [SerializeField] private CharacterSkill water;
    [SerializeField] private CharacterSkill earth;
    [SerializeField] private CharacterSkill fire;
    [SerializeField] private CharacterSkill wind;
    private CharacterAttack characterAttack;

    void SetSkill()
    {
        switch (playerSkills.skill1)
        {
            case PlayerSkills.Element.Water:
                characterAttack.ElementalSkill1 = water;
                break;
            case PlayerSkills.Element.Earth:
                characterAttack.ElementalSkill1 = earth;
                break;
            case PlayerSkills.Element.Fire:
                characterAttack.ElementalSkill1 = fire;
                break;
            case PlayerSkills.Element.Wind:
                characterAttack.ElementalSkill1 = wind;
                break;
        }

        switch (playerSkills.skill2)
        {
            case PlayerSkills.Element.Water:
                characterAttack.ElementalSkill2 = water;
                break;
            case PlayerSkills.Element.Earth:
                characterAttack.ElementalSkill2 = earth;
                break;
            case PlayerSkills.Element.Fire:
                characterAttack.ElementalSkill2 = fire;
                break;
            case PlayerSkills.Element.Wind:
                characterAttack.ElementalSkill2 = wind;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        characterAttack = GetComponent<CharacterAttack>();
        SetSkill();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
