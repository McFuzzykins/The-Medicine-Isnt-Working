using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : Observer
{
    public PlayerBehaviour player;

    [SerializeField]
    public Slider healthbar;
    [SerializeField]
    private Image healthFill;
    [SerializeField]
    public TMP_Text pills;
    [SerializeField]
    public Slider psychosisBar;
    [SerializeField]
    private Image meter;

    public float decayRate;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (player)
        {
            pills.SetText("Pills: " + player.pillCount);
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
            else if (player.pillCount >= 12)
            {
                SceneManager.LoadScene(sceneName: "Win Screen");
            }

            UpdateHealth(player.curHp);

            if (psychosisBar.value > 0 && player.correctMeds == false)
            {
                psychosisBar.value -= decayRate * Time.deltaTime;
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
