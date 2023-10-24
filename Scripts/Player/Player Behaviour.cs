using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : Subject
{
    private Rigidbody rb;
    public GameManager gm;
    private PostProcessingManager ppm;

    public int maxHp = 100;
    public int curHp = 100;
    public int pillCount;

    public bool canDmg = true;
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
            gm.psychosisBar.value = Mathf.Lerp(pillCount, 0, 10);
            //NotifyObservers();

            Destroy(collider.gameObject);
            Debug.Log("Object Destroyed");
        }
        else if (collider.gameObject.tag == "Enemy")
        {
            if (canDmg)
            {
                Debug.Log("Ouch!");
                curHp -= 10;

                gm.healthbar.value = curHp;
                //NotifyObservers();

                canDmg = false;
                StartCoroutine(IFrames(2f));
                canDmg = true;
                Debug.Log("Can Dmg: " + canDmg);
            }
        }

        IEnumerator IFrames(float time)
        {
            yield return new WaitForSeconds(time);
            Debug.Log("IFrames: " + Time.time);
        }
    }
}
