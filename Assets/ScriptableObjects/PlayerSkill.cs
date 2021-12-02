using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Skill", menuName = "ScriptableObjects/PlayerSkill")]
public class PlayerSkills : ScriptableObject
{
    public enum Element { Water, Earth, Fire, Wind }
    public Element skill1, skill2;
}
