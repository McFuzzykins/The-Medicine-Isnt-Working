using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int hp = 10;

    [SerializeField]
    private GameObject itemDrop;

    private Vector3 spawn;
    
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hp -= 5;
        }
    }

    void Update()
    {
        spawn = this.transform.position;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        Instantiate(itemDrop);
    }
}
