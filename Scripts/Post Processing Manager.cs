using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : Observer
{
    public GameManager gm;
    private int lastPlayerHP;
    [SerializeField]
    private PlayerBehaviour player;

    [SerializeField]
    private Volume ppVolume;

    [Header("Post Processing Effects")]
    private Vignette vg;
    private ChromaticAberration chrom;
    private Bloom bloom;

    private void Start()
    {
        ppVolume = this.GetComponent<Volume>();
        ppVolume.profile.TryGet(out vg);
        ppVolume.profile.TryGet(out chrom);
        ppVolume.profile.TryGet(out bloom);

        lastPlayerHP = player.curHp;
    }

    private void Update()
    {
        vg.intensity.value = 1 - (gm.psychosisBar.value / 3);
        chrom.intensity.value = 1 - (gm.psychosisBar.value / 3);

        if (Input.GetKeyDown(KeyCode.P))
        {
            ppVolume.enabled = !ppVolume.enabled;
        }
    }

    public override void Notify(Subject subject)
    {
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
            }
        }
    }

    IEnumerator HitBloomEffect()
    {
        Debug.Log("Entered Coroutine");
        float counter = Time.deltaTime;

        bloom.intensity.value = 8;
        bloom.intensity.value = Mathf.Lerp(8, 0, counter / 3);
        Debug.Log("Bloom ramp Finished");

        yield return null;
    }
}
