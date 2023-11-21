using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    public GameManager gm;
    public float decayRate;
    private int lastPlayerHP;
    [SerializeField]
    private PlayerBehaviour player;

    [SerializeField]
    public Volume ppVolume;

    [Header("Post Processing Effects")]
    private Vignette vg;
    private ChromaticAberration chrom;
    private Bloom bloom;
    private MotionBlur motionBlur;

    public void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            player = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
            gm = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();

            lastPlayerHP = player.curHp;
        }
    }

    private void Start()
    {
        ppVolume = this.GetComponent<Volume>();
        ppVolume.profile.TryGet(out vg);
        ppVolume.profile.TryGet(out chrom);
        ppVolume.profile.TryGet(out bloom);
        ppVolume.profile.TryGet(out motionBlur);
    }

    private void Update()
    {
        if (player)
        {
            vg.intensity.value = 1 - (gm.psychosisBar.value / gm.psychosisBar.maxValue);
            chrom.intensity.value = 1 - (gm.psychosisBar.value / gm.psychosisBar.maxValue);

            if (lastPlayerHP > player.curHp)
            {
                bloom.intensity.value = 8;
                lastPlayerHP = player.curHp;
            }

            if (bloom.intensity.value > 0)
            {
                bloom.intensity.value -= decayRate * Time.deltaTime;
            }
        }
    }

    public void ppVolumeToggle()
    {
        ppVolume.enabled = !ppVolume.enabled;
    }
}
