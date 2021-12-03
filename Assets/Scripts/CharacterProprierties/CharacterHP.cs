using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterHP : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private bool destroyOnDeath;
    public UnityEvent onChangeHealth, onDie;

    public float Health
    {
        get => health;
        set
        {
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
