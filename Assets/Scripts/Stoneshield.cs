using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoneshield : MonoBehaviour
{
    Transform shield;

    // Start is called before the first frame update
    void Start()
    {
        shield = transform.GetChild(3);
    }

    // Update is called once per frame
    void Update()
    {
        shield.gameObject.SetActive(Input.GetKey(KeyCode.B));
    }
}
