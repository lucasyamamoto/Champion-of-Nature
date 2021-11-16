using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private CharacterHP playerHP;
    [SerializeField] private float HPPerHeart;
    private Stack<GameObject> hearts;

    void Add()
    {
        Vector3 position = new Vector3(transform.position.x + 0.7f * hearts.Count, transform.position.y, transform.position.z);
        hearts.Push(Instantiate(heartPrefab, position, transform.rotation));
        hearts.Peek().transform.parent = transform;
    }

    void Remove()
    {
        Destroy(hearts.Pop());
    }

    // Start is called before the first frame update
    void Start()
    {
        hearts = new Stack<GameObject>();
        if (HPPerHeart == 0)
        {
            HPPerHeart = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        while (playerHP.Health / HPPerHeart > hearts.Count)
        {
            Add();
        }

        while (playerHP.Health / HPPerHeart < hearts.Count)
        {
            Remove();
        }
    }
}
