using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : Observer
{
    public PlayerBehaviour player;
    public GameObject[] winCons;

    [SerializeField]
    public Slider healthbar;
    [SerializeField]
    private Image healthFill;
    [SerializeField]
    public Slider psychosisBar;
    [SerializeField]
    private Image meter;
    [SerializeField]
    public TMP_Text pickupNotification;

    public float decayRate;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (player)
        {
            SetHealthInitial();
            SetPsychosisInitial();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            if (player.curHp <= 0)
            {
                SceneManager.LoadScene(sceneName: "Lose Screen");
            }
            else if (player.pillCount >= 10)
            {
                SceneManager.LoadScene(sceneName: "Win Screen");
            }

            UpdateHealth(player.curHp);

            if (psychosisBar.value > 0 && player.correctMeds == false)
            {
                psychosisBar.value -= decayRate * Time.deltaTime;
            }

            foreach (GameObject winCon in winCons)
            {
                //Debug.Log(Vector3.Distance(player.transform.position, winCon.transform.position));

                if (Vector3.Distance(player.transform.position, winCon.transform.position) <= 2)
                {
                    pickupNotification.enabled = true;
                    pickupNotification.gameObject.SetActive(true);
                    player.PickUp(winCon);
                }
                else
                {
                    pickupNotification.enabled = false;
                    pickupNotification.gameObject.SetActive(false);
                }
            }
        }
    }

    public override void Notify(Subject subject)
    {
       
    }

    public void SetHealthInitial()
    {
        healthbar.maxValue = player.maxHp;
        healthbar.value = player.maxHp;
        player.curHp = player.maxHp;
    }

    public void UpdateHealth(int currentHp)
    {
        healthbar.value = currentHp;
    }

    public void SetPsychosisInitial()
    {
        psychosisBar.maxValue = 15;
        psychosisBar.value = player.pillCount;
    }
}
