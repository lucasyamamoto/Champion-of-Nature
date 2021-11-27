using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterSkill : MonoBehaviour
{
    [SerializeField] private Color braceletColor;

    public Color BraceletColor { get => braceletColor; }

    public abstract InputManager.KeyStatus CurrentInput { get; set; }
}
