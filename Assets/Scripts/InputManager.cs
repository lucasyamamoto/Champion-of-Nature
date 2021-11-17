using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager : MonoBehaviour
{
    public class KeyStatus
    {
        public bool keyDown;
        public bool key;
        public bool keyUp;

        public KeyStatus()
        {
            keyDown = false;
            key = false;
            keyUp = false;
        }
        public KeyStatus(bool keyDown,bool key,bool keyUp)
        {
            this.keyDown = keyDown;
            this.key = key;
            this.keyUp = keyUp;
        }

        public KeyStatus(string keyName)
        {
            this.keyDown = Input.GetButtonDown(keyName);
            this.key = Input.GetButton(keyName);
            this.keyUp = Input.GetButtonUp(keyName);
        }
    }

    [SerializeField] protected GameObject target;

    public GameObject Target { get => target; set => target = value; }

    public abstract float HorizontalAxis();
    public abstract float VerticalAxis();
    public abstract KeyStatus Jump();
    public abstract KeyStatus Attack();
    public abstract KeyStatus ElementalSkill1();
    public abstract KeyStatus ElementalSkill2();
}
