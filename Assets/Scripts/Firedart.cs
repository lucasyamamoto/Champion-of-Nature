using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firedart : CharacterSkill
{
    [SerializeField] private float delay;
    [SerializeField] private GameObject projectile;
    private bool isReady;
    [SerializeField] private bool isEnemy;

    private InputManager.KeyStatus currentInput;

    public override InputManager.KeyStatus CurrentInput { get => currentInput; set => currentInput = value; }

    IEnumerator Shoot()
    {
        isReady = false;

        Transform newProjectile = Instantiate(projectile.transform, transform.position + projectile.transform.localPosition * transform.localScale.x, projectile.transform.rotation);
        newProjectile.gameObject.SetActive(true);

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
        if (((currentInput.keyDown && !isEnemy) || (Input.GetKeyDown(KeyCode.N) && isEnemy)) && isReady)
        {
            StartCoroutine(Shoot());
        }
    }
}
