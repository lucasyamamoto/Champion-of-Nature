using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private CharacterHP characterHP;
    private Animator animator;
    private CharacterMovement characterMovement;
    private CharacterAttack characterAttack;
    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackTime;
    private bool knockedBack;
    private bool knockRight;

    IEnumerator Knockback()
    {
        characterMovement.Block = true;
        characterAttack.Block = true;
        
        animator.SetTrigger("Hit");
        knockedBack = true;

        yield return new WaitForSecondsRealtime(knockbackTime);

        characterMovement.Block = false;
        characterAttack.Block = false;
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
        characterAttack = GetComponentInParent<CharacterAttack>();
        knockedBack = false;
        knockRight = true;
    }

    void FixedUpdate()
    {
        if (knockedBack)
        {
            float direction = (knockRight) ? -1 : 1;
            rigidBody.velocity = new Vector2(knockbackForce * direction, rigidBody.velocity.y);
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
            if (transform.parent.gameObject.activeSelf)
            {
                float reference = (other.transform.parent) ? other.transform.parent.position.x : other.transform.position.x;
                knockRight = (transform.position.x <= reference);
                StartCoroutine(Knockback());
            }
        }
    }
}
