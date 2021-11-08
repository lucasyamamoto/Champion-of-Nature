using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoneshield : MonoBehaviour
{
    [SerializeField] private GameObject shieldPrefab;
    private GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        shield = Instantiate(shieldPrefab, transform.position + shieldPrefab.transform.localPosition * transform.localScale.x, shieldPrefab.transform.rotation);
        shield.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        shield.gameObject.SetActive(Input.GetKey(KeyCode.B));
    }
}
