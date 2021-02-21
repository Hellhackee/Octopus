using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Light))]
public class LightIntensityAnim : MonoBehaviour
{
    [SerializeField] private float _minIntensity;
    [SerializeField] private float _maxIntensity;
    [SerializeField] private float _loopTime;

    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
        _light.intensity = _minIntensity;
        _light.DOIntensity(_maxIntensity, _loopTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
