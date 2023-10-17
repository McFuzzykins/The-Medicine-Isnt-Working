using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement player;

    [SerializeField]
    private Volume ppVolume;

    [Header("Post Processing Effects")]
    private Vignette vg;
    private ChromaticAberration chrom;

    private void Start()
    {
        ppVolume = this.GetComponent<Volume>();
        ppVolume.profile.TryGet(out vg);
        ppVolume.profile.TryGet(out chrom);
    }

    private void Update()
    {
        vg.intensity.value = 1 - (player.psychosisBar.value / 3);
        chrom.intensity.value = 1 - (player.psychosisBar.value / 3);
    }
}
