using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemySpawn;
    public Transform[] patrolPoints;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject enemyClone = Instantiate(enemyPrefab, enemySpawn);
            enemyClone.GetComponent<EnemyPatrol>().points = patrolPoints;
        }
    }
}
