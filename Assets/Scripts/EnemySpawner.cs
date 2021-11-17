using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private float spawnDistance;
    [SerializeField] private float spawnRange;
    private float nextSpawnPoint;

    void SpawnEnemy()
    {
        GameObject original = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        Instantiate(
            original, 
            transform.position, 
            original.transform.rotation
        ).GetComponent<InputManager>().Target = target;
    }

    void GenerateNextSpawnPoint()
    {
        nextSpawnPoint += spawnDistance + Random.Range(-spawnRange, spawnRange);
    }

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnPoint = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextSpawnPoint <= transform.position.x)
        {
            SpawnEnemy();
            GenerateNextSpawnPoint();
        }
    }
}
