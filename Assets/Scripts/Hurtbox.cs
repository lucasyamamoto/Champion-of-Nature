using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private CharacterHP characterHP;
    private Animator animator;
    private CharacterMovement characterMovement;
    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackTime;
    private bool knockedBack;

    IEnumerator Knockback()
    {
        characterMovement.Block = true;
        animator.SetTrigger("Hit");
        knockedBack = true;
        yield return new WaitForSecondsRealtime(knockbackTime);

        characterMovement.Block = false;
        knockedBack = false;

        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponentInParent<Rigidbody2D>();
        characterHP = GetComponentInParent<CharacterHP>();
        animator = GetComponentInParent<Animator>();
        characterMovement = GetComponentInParent<CharacterMovement>();
        knockedBack = false;
    }

    void FixedUpdate()
    {
        if (knockedBack)
        {
            rigidBody.velocity = new Vector2(-knockbackForce, rigidBody.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if this hurtbox collided with an hitbox
        Hitbox hitbox = other.gameObject.GetComponent<Hitbox>();
        if(hitbox && characterHP)
        {
            // Receive damage
            print($"{this.transform.parent.name} got {hitbox.Damage} damage");
            characterHP.Health -= hitbox.Damage;
            StartCoroutine(Knockback());
        }
    }
}
