using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform heartPrefab;
    [SerializeField] private CharacterHP playerHP;
    [SerializeField] private float HPPerHeart;
    [SerializeField] private float distanceBetweenHearts;
    private Stack<RectTransform> hearts;

    void Add()
    {
        RectTransform prefab = Instantiate(heartPrefab) as RectTransform;
        prefab.transform.SetParent(transform, false);
        prefab.localPosition += new Vector3(distanceBetweenHearts * hearts.Count, 0, 0);
        hearts.Push(prefab);
    }

    void Remove()
    {
        Destroy(hearts.Pop().transform.gameObject);
    }

    public void UpdateHealthBar()
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

    // Start is called before the first frame update
    void Start()
    {
        hearts = new Stack<RectTransform>();
        if (HPPerHeart == 0)
        {
            HPPerHeart = 1;
        }

        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
