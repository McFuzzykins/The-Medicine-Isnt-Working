using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemySpawn;
    public Transform[] patrolPoints;
    private int limit = 1;
    public int enemyCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && enemyCount < limit)
        {
            GameObject enemyClone = Instantiate(enemyPrefab, enemySpawn);
            enemyClone.GetComponent<EnemyPatrol>().points = patrolPoints;
            enemyClone.GetComponent<Enemy>().spawner = this;
            ++enemyCount;
        }
    }
}
