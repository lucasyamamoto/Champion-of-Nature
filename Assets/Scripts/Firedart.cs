using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firedart : MonoBehaviour
{
    [SerializeField] private float delay;
    Transform projectile;
    private bool isReady;
    [SerializeField] private bool isEnemy;

    IEnumerator Shoot()
    {
        isReady = false;

        Transform newProjectile = Instantiate(projectile, projectile.position, projectile.rotation); ;
        newProjectile.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(delay);

        isReady = true;

        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        projectile = transform.GetChild(2);
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (((Input.GetKeyDown(KeyCode.V) && !isEnemy) || (Input.GetKeyDown(KeyCode.N) && isEnemy)) && isReady)
        {
            StartCoroutine(Shoot());
        }
    }
}
