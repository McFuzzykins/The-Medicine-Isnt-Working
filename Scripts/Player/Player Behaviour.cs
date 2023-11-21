using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    public GameManager gm;

    public int maxHp = 100;
    public int curHp = 100;
    public int pillCount;

    public bool canDmg = true;
    public float timer;
    public int iframeTime = 3;
    public bool correctMeds = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pillCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (canDmg == false)
        {
            float currentTime = Time.time;
            if (currentTime - timer >= iframeTime)
            {
                canDmg = true;
            }
        }
    }

    public void PickUp(GameObject obj)
    {
        if (Input.GetKeyDown("e"))
        {
            pillCount += 5;
            gm.psychosisBar.value = pillCount;
            obj.SetActive(false);
        }

        //NotifyObservers();

       // gm.pickupNotification.SetActive(false);
    }

        /*
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        */

    /*
    public void Attack()
    {
        if ()
        {

        }
    }
    */

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            if (canDmg == true)
            {
                Debug.Log("Ouch!");
                curHp -= 10;

                //ppm.bloom.intensity.value = 8;
                gm.psychosisBar.value -= 3;
                //NotifyObservers();
                canDmg = false;
                timer = Time.time;
            }
        }
    }
}
