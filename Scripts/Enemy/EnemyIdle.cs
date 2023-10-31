using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : IEnemyState
{
    public void Enter(Enemy enemy)
    {
        Debug.Log("Idle State");
        enemy.currentState = this;
    }

    public void Execute(Enemy enemy)
    {
        if (enemy.distFromPlayer <= 20f)
        {
            EnemyPatrol patrolState = new EnemyPatrol();
            patrolState.Enter(enemy);
        }
    }
}
