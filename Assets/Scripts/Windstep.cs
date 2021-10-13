using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windstep : MonoBehaviour
{
    private JumpMovement jumpMovement;

    // Start is called before the first frame update
    void Start()
    {
        jumpMovement = GetComponent<JumpMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            jumpMovement.DoubleJump();
        }
    }
}
