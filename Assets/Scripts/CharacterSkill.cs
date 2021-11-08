using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterSkill : MonoBehaviour
{
    public abstract InputManager.KeyStatus CurrentInput { get; set; }
}
