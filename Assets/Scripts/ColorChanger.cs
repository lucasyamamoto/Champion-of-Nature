using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color color;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        print(spriteRenderer.color);
        spriteRenderer.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
