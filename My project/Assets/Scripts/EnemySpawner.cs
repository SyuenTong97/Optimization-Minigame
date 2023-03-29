using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 5f;
    private int enemies;
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
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemies < 20)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-23.14f, 23.14f), Random.Range(-10f, 10f), 0), Quaternion.identity);
        }
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
