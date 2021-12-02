using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxDuration;
    [SerializeField] private float upForce;
    private Rigidbody2D rigidBody;

    public float Speed { get => speed; set => speed = value; }

    IEnumerator LifeSpan()
    {
        yield return new WaitForSecondsRealtime(maxDuration);

        Destroy(gameObject);

        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        rigidBody.AddForce(new Vector2(0f, upForce), ForceMode2D.Impulse);
        StartCoroutine(LifeSpan());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Hurtbox>() || collision.GetComponent<Shield>() || collision.transform.name == "Ground")
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 4f);
        }
    }
}
