using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CharacterMovement))]
public class InvocationAttack : CharacterSkill
{
    [SerializeField] private float delay;
    [SerializeField] private GameObject projectile;
    private Animator animator;
    private CharacterMovement characterMovement;
    private GameObject projectileRight;
    private GameObject projectileLeft;
    private GameObject newProjectile;
    private bool isReady;
    public bool releaseProjectile;

    private InputManager.KeyStatus currentInput;

    public override InputManager.KeyStatus CurrentInput { get => currentInput; set => currentInput = value; }

    IEnumerator Shoot()
    {
        isReady = false;
        characterMovement.Block = true;

        // Generate projectile
        GameObject baseObject = (transform.rotation.y == 0f) ? projectileRight : projectileLeft;
        newProjectile = Instantiate(baseObject, baseObject.transform.position, baseObject.transform.rotation);
        newProjectile.SetActive(false);

        // Start animation
        animator.SetTrigger("Attacking");

        yield return new WaitForSecondsRealtime(delay);

        isReady = true;

        yield return null;
    }

    void ReleaseProjectile()
    {
        // Update projectile direction
        float direction = ((transform.rotation.y == 0f) ? 1f : -1f);
        newProjectile.transform.position = transform.position + newProjectile.transform.localPosition * transform.localScale.x;

        // Activate projectile
        newProjectile.SetActive(true);

        // Reset state
        newProjectile = null;
        characterMovement.Block = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize member variables
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        isReady = true;
        currentInput = new InputManager.KeyStatus();
        newProjectile = null;
        releaseProjectile = false;

        // Generate right version of projectile
        projectileRight = Instantiate(projectile);
        projectileRight.SetActive(false);
        projectileRight.GetComponent<InputManager>().Target = GetComponent<InputManager>().Target;

        // Generate left version of projectile
        projectileLeft = Instantiate(projectileRight);
        projectileLeft.SetActive(false);
        projectileLeft.GetComponent<InputManager>().Target = GetComponent<InputManager>().Target;
        projectileLeft.GetComponent<Projectile>().Speed *= -1f;
        projectileLeft.transform.Rotate(0f, 180f, 0f);
        projectileLeft.transform.position = new Vector3(
            projectileLeft.transform.position.x,
            -projectileLeft.transform.position.y,
            projectileLeft.transform.position.z
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInput.keyDown && isReady)
        {
            StartCoroutine(Shoot());
        }

        if (newProjectile && releaseProjectile)
        {
            ReleaseProjectile();
        }
    }
}
