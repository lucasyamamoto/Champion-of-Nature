using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EldritchEdge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Attack
        transform.GetChild(1).gameObject.SetActive(Input.GetKey(KeyCode.Z));
    }
}
