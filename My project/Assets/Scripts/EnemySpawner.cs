using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnTime = 4f;
    public float maxSpawnTime = 7f;
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = (Random.Range(minSpawnTime, maxSpawnTime));
        StartCoroutine(spawnEnemy(spawnTime, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-16.46f, 16.46f), Random.Range(-10f, 10f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
