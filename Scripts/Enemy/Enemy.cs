using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public IEnemyState currentState;
    public EnemySpawner spawner;
    public Animator animCont;

    public int hp;
    public Slider healthbar;
    public Image healthFill;

    public float distFromPlayer;
    public float chaseDist = 10f;
    public float attackDist = 2f;
    public PlayerBehaviour player;

    public Transform[] points;
    private int destPoint = 0;
    public NavMeshAgent agent;

    private void Awake()
    {
        healthbar.maxValue = hp;
        animCont = GetComponent<Animator>();
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
        }

        currentState = new EnemyIdle();
        Debug.Log(currentState + " Enemy Debug");
    }

    void Update()
    {
        healthbar.value = hp;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

        distFromPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        currentState.Execute(this);
        //Debug.Log("distFromPlayer " + distFromPlayer);
    }

    private void OnDestroy()
    {
        --spawner.enemyCount;
    }

    public void NextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    public void OnCollision(Collider collider)
    {
        if (collider.tag == "Player")
        {
            hp -= 3;
        }
    }
}
