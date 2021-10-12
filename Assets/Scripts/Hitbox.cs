using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private float damage;
    public float Damage { get => damage; set => damage = value; }

    private PlayerMovement parentMovement;
    private BoxCollider boxCollider;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        parentMovement = GetComponentInParent<PlayerMovement>();
        boxCollider = GetComponent<BoxCollider>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(parentMovement && (boxCollider.transform.localPosition.x >= 0 != parentMovement.FacingRight))
        {
            // Flip box collider
            boxCollider.transform.localPosition = new Vector3(
                boxCollider.transform.localPosition.x * (-1f),
                boxCollider.transform.localPosition.y,
                boxCollider.transform.localPosition.z
            );

            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
