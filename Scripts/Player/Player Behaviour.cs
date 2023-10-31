using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : Subject
{
    private Rigidbody rb;
    public GameManager gm;
    public PostProcessingManager ppm;

    public int maxHp = 100;
    public int curHp = 100;
    public int pillCount;

    public bool canDmg = true;
    public float timer;
    public int iframeTime = 3;
    public bool correctMeds = false;

    void OnEnable()
    {
        if (ppm)
        {
            Attach(ppm);
        }

        if (gm)
        {
            Attach(gm);
        }
    }

    void OnDisable()
    {
        if (ppm)
        {
            Detach(ppm);
        }

        if (gm)
        {
            Detach(gm);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pillCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (curHp <= 0)
        {
            Destroy(this.gameObject);
        }

        if (canDmg == false)
        {
            float currentTime = Time.time;
            if (currentTime - timer >= iframeTime)
            {
                canDmg = true;
            }
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Door")
        {
            Debug.Log("Door");
        }
        else if (collider.gameObject.tag == "WinCon")
        {
            pillCount += 5;
            gm.pills.SetText("Pills: " + pillCount);
            gm.psychosisBar.value = pillCount;
            //NotifyObservers();

            Destroy(collider.gameObject);
            Debug.Log("Object Destroyed");
        }
        else if (collider.gameObject.tag == "Enemy")
        {
            if (canDmg == true)
            {
                Debug.Log("Ouch!");
                curHp -= 10;

                ppm.bloom.intensity.value = 8;
                gm.psychosisBar.value -= 3;
                //NotifyObservers();
                canDmg = false;
                timer = Time.time;
            }
        }
    }
}
