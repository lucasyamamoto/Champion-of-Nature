using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class Firedart : CharacterSkill
{
    [SerializeField] private float delay;
    [SerializeField] private GameObject projectile;
    private bool isReady;

    private InputManager.KeyStatus currentInput;

    public override InputManager.KeyStatus CurrentInput { get => currentInput; set => currentInput = value; }

    IEnumerator Shoot()
    {
        isReady = false;

        float direction = ((transform.rotation.y == 0f) ? 1f : -1f);

        Vector3 newProjectilePos = transform.position + projectile.transform.localPosition * transform.localScale.x * direction;

        GameObject newProjectile = Instantiate(projectile, newProjectilePos, projectile.transform.rotation);
        newProjectile.GetComponent<Projectile>().Speed *= direction;
        newProjectile.SetActive(true);

        yield return new WaitForSecondsRealtime(delay);

        isReady = true;

        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        isReady = true;
        currentInput = new InputManager.KeyStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInput.keyDown && isReady)
        {
            StartCoroutine(Shoot());
        }
    }
}
