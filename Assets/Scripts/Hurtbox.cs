using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if this hurtbox collided with an hitbox
        Hitbox hitbox = other.gameObject.GetComponent<Hitbox>();
        if(hitbox)
        {
            // Receive damage
            print($"{this.transform.parent.name} got {hitbox.Damage} damage from {other.transform.parent.name}");
        }
    }
}
