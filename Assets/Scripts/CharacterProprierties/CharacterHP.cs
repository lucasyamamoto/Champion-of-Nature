using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterHP : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private bool destroyOnDeath;
    [SerializeField] private float invincibilityDuration;
    private bool invincible;
    public bool Invincible { get => invincible; }
    public UnityEvent onChangeHealth, onDie;


    public float Health
    {
        get => health;
        set
        {
            if (!invincible)
            {
                if (value < health)
                {
                    BecomeInvincible();
                }

                health = value;
                if (health <= 0)
                {
                    health = 0;
                    gameObject.SetActive(false);
                    if (destroyOnDeath)
                    {
                        Destroy(gameObject);
                    }
                    onDie.Invoke();
                }

                onChangeHealth.Invoke();
            }
        }
    }

    IEnumerator Invincibility()
    {
        invincible = true;
        print("Invincible");
        yield return new WaitForSecondsRealtime(invincibilityDuration);

        invincible = false;
        print("Not invincible");
        yield return null;
    }

    void BecomeInvincible()
    {
        StartCoroutine(Invincibility());
    }

    // Start is called before the first frame update
    void Start()
    {
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
