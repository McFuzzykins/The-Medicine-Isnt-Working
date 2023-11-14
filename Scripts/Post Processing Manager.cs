using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : Observer
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
    public Bloom bloom;
    public MotionBlur motionBlur;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject); 
    }

    private void Start()
    {
        if (player)
        {
            ppVolume = this.GetComponent<Volume>();
            ppVolume.profile.TryGet(out vg);
            ppVolume.profile.TryGet(out chrom);
            ppVolume.profile.TryGet(out bloom);
            ppVolume.profile.TryGet(out motionBlur);

            lastPlayerHP = player.curHp;
        }
    }

    private void Update()
    {
        if (player)
        {
            vg.intensity.value = 1 - (gm.psychosisBar.value / gm.psychosisBar.maxValue);
            chrom.intensity.value = 1 - (gm.psychosisBar.value / gm.psychosisBar.maxValue);

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

    public override void Notify(Subject subject)
    {
        /*
        if (!player)
        {
            player = subject.GetComponent<PlayerBehaviour>();
        }
        // Only reason player should notify PPM is if player was damaged
        if (player)
        {
            Debug.Log("Notified PPM");
            if (player.curHp < lastPlayerHP)
            {
                bloom.intensity.value = 8;
                StartCoroutine(HitBloomEffect());
                Debug.Log("Coroutine Finished");
                lastPlayerHP = player.curHp;
            }
        }
        */
    }
}
