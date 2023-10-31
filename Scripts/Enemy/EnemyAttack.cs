using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour, IEnemyState
{
    public void Enter(Enemy enemy)
    {
        enemy.currentState = this;
    }

    public void Execute(Enemy enemy)
    {
        if (enemy.distFromPlayer >= enemy.attackDist)
        {
            //enemy.animCont.SetBool("isAttacking", false);
            EnemyPatrol patrolState = new EnemyPatrol();
            patrolState.Enter(enemy);
        }
        else
        {
            enemy.animCont.SetBool("isAttacking", true);
            Debug.Log("Enemy Attack");
        }
    }
}
