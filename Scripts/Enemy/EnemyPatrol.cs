using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour, IEnemyState
{
    public void Enter(Enemy enemy)
    {
        Debug.Log("Entered Enemy Patrol State");
        enemy.agent = enemy.GetComponent<NavMeshAgent>();

        enemy.currentState = this;
        Debug.Log(enemy.currentState + "Patrol Debug");
    }

    public void Execute(Enemy enemy)
    {
        /*
        if (enemy.distFromPlayer <= enemy.attackDist)
        {
            EnemyAttack attackState = new EnemyAttack();
            attackState.Enter(enemy);
        }
        */
        if (enemy.distFromPlayer <= enemy.chaseDist)
        { 
            enemy.transform.LookAt(enemy.player.transform.position);
            enemy.agent.destination = enemy.player.transform.position;
        }
        else if (!enemy.agent.pathPending && enemy.agent.remainingDistance < 0.5f)
        {
            enemy.NextPoint();
        }
    }
}
