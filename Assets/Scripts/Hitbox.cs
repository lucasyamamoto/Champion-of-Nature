using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private float damage;
    public float Damage { get => damage; set => damage = value; }

    private CharacterMovement parentMovement;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        parentMovement = GetComponentInParent<CharacterMovement>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(parentMovement && (boxCollider.transform.localPosition.x >= 0 != parentMovement.FacingRight))
        {
            // Flip box collider
            boxCollider.transform.localPosition = new Vector2(
                boxCollider.transform.localPosition.x * (-1f),
                boxCollider.transform.localPosition.y
            );

            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
