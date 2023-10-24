using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerBehaviour player;
    public EnemySpawner spawner;
    private int hp = 10;

    [SerializeField]
    private GameObject itemDrop;

    void Start()
    {
        
    }
    
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            player = collider.gameObject.GetComponent<PlayerBehaviour>();
            if (player.canDmg)
            {
                hp -= 5;
            }
            else
            {
                Debug.Log("I Count Six Seconds");
            }
        }
    }

    void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    /*
    void Attack()
    {
        if ()
    }
    */

    private void OnDestroy()
    {
        Instantiate(itemDrop, this.transform);
        --spawner.enemyCount;
    }
}
