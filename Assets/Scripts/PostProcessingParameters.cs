using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingParameters : MonoBehaviour
{
    [SerializeField] private VolumeProfile globalVolume;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform demonTransform;


    private FilmGrain _filmGrain;
    private Vignette _vignette;
    private void Start()
    {
        globalVolume.TryGet<FilmGrain>(out _filmGrain);
        globalVolume.TryGet<Vignette>(out _vignette);

        _filmGrain.intensity.Override(0.1f);
        _vignette.intensity.Override(0.2f);
    }

    private void Update()
    {
        var distance = (playerTransform.position - demonTransform.position).magnitude;
        var scale = Mathf.Min(20 / (15 + 5 * distance), 1);
        _filmGrain.intensity.Override(scale);
        _vignette.intensity.Override(scale * 0.2f + 0.2f);
    }
}
