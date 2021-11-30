using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisorChecker : MonoBehaviour
{
    private bool collided;

    public bool Collided { get => collided; set => collided = value; }

    // Start is called before the first frame update
    void Start()
    {
        collided = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        collided = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collided = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collided = true;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        collided = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        collided = false;
    }
}
