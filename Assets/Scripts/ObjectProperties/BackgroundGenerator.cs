using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> backgroundPrefabs;
    [SerializeField] private float backgroundSize;
    private float nextGenPoint;

    void GenerateBackground()
    {
        GameObject original = backgroundPrefabs[Random.Range(0, backgroundPrefabs.Count)];
        Instantiate(original, new Vector3(
            nextGenPoint + backgroundSize*2,
            original.transform.position.y,
            original.transform.position.z
        ), original.transform.rotation);
    }

    void GenerateNextGenPoint()
    {
        nextGenPoint += backgroundSize;
    }

    // Start is called before the first frame update
    void Start()
    {
        nextGenPoint = (backgroundPrefabs.Count > 0) ? transform.position.x - backgroundSize : float.PositiveInfinity;
        GenerateBackground();
        GenerateNextGenPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextGenPoint <= transform.position.x)
        {
            GenerateBackground();
            GenerateNextGenPoint();
        }
    }
}
