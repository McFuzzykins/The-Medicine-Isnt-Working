using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    public NavMeshAgent agent;
    public float minDist = 10f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = true;
        
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }

        NextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        
        if (distance <= minDist)
        {
            transform.LookAt(player);
            agent.destination = player.position;
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            NextPoint();
        }
    }

    void NextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
}
