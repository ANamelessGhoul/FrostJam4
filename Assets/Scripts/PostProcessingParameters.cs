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
    private LensDistortion _lensDistortion;
    private void Start()
    {
        globalVolume.TryGet<FilmGrain>(out _filmGrain);
        globalVolume.TryGet<Vignette>(out _vignette);
        globalVolume.TryGet<LensDistortion>(out _lensDistortion);

        _filmGrain.intensity.Override(0.1f);
        _vignette.intensity.Override(0.2f);
        _lensDistortion.intensity.Override(0f);
    }

    private void Update()
    {
        var distance = (playerTransform.position - demonTransform.position).magnitude;
        var scale = Mathf.Min(30 / (10 + 15 * distance), 1);
        _filmGrain.intensity.Override(scale);
        _vignette.intensity.Override(scale * 0.2f + 0.2f);
        _lensDistortion.intensity.Override(scale * 0.5f);
    }
}
