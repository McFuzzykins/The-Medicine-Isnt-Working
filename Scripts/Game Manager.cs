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

    // Start is called before the first frame update
    void Start()
    {
        pills.SetText("Pills: " + player.pillCount);
        SetHealthInitial();
        SetPsychosisInitial();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            SceneManager.LoadScene(sceneName: "Lose Screen");
        }
        else if (player.pillCount == 6)
        {
            SceneManager.LoadScene(sceneName: "Win Screen");
        }
        //UpdatePsychosisBar();
    }

    public override void Notify(Subject subject)
    {
        if (player)
        {
            UpdateHealth(player.curHp);
            UpdatePsychosisBar();
            pills.SetText("Pills: " + player.pillCount);
        }
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
        psychosisBar.maxValue = 10;
        psychosisBar.value = player.pillCount;
    }

    public void UpdatePsychosisBar()
    {
        if (!player.correctMeds)
        {
            psychosisBar.value -= 0.5f * Time.deltaTime;
            psychosisBar.value = player.pillCount;
        }
    }
}
