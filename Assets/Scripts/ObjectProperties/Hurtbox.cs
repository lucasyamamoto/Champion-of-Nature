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
    private BossAttack bossAttack;
    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackTime;
    [SerializeField] private float superKnockbackMultiplicator;
    private bool knockedBack;
    private bool knockRight;
    private bool superKnockback;

    IEnumerator Knockback()
    {
        characterMovement.Block = true;
        if (characterAttack)
        {
            characterAttack.Block = true;
        }
        else if (bossAttack)
        {
            bossAttack.Block = true;
        }
        
        animator.SetTrigger("Hit");
        knockedBack = true;

        yield return new WaitForSecondsRealtime(knockbackTime);

        characterMovement.Block = false;
        if (characterAttack)
        {
            characterAttack.Block = false;
        }
        else if (bossAttack)
        {
            bossAttack.Block = false;
        }
        knockedBack = false;

        yield return null;
    }

    IEnumerator SuperKnockback()
    {
        characterMovement.Block = true;
        if (characterAttack)
        {
            characterAttack.Block = true;
        }
        else if (bossAttack)
        {
            bossAttack.Block = true;
        }

        animator.SetTrigger("Hit");
        knockedBack = true;
        superKnockback = true;

        yield return new WaitForSecondsRealtime(knockbackTime);

        characterMovement.Block = false;
        if (characterAttack)
        {
            characterAttack.Block = false;
        }
        else if (bossAttack)
        {
            bossAttack.Block = false;
        }
        knockedBack = false;
        superKnockback = false;

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
        bossAttack = GetComponentInParent<BossAttack>();
        knockedBack = false;
        knockRight = true;
        superKnockback = false;
    }

    void FixedUpdate()
    {
        if (knockedBack)
        {
            float direction = (knockRight) ? -1 : 1;
            if(superKnockback)
            {
                direction *= superKnockbackMultiplicator;
            }
            rigidBody.velocity = new Vector2(knockbackForce * direction, rigidBody.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print($"{this.transform.parent.name} collided with {other.transform.name} damage");
        // Check if this hurtbox collided with an hitbox
        Hitbox hitbox = other.gameObject.GetComponent<Hitbox>();
        if(hitbox && characterHP && !superKnockback)
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
        else
        {
            Knockback knockComponent = other.gameObject.GetComponent<Knockback>();
            if (knockComponent && transform.parent.gameObject.activeSelf)
            {
                float reference = (other.transform.parent) ? other.transform.parent.position.x : other.transform.position.x;
                knockRight = (transform.position.x <= reference);
                StartCoroutine(SuperKnockback());
            }
        }
    }
}
