using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private float _levelTime;
    [SerializeField] private Slider _slider;

    public event UnityAction LevelFinished;

    private void Start()
    {
        _slider.DOValue(1f, _levelTime).SetEase(Ease.Linear).OnComplete(() => LevelFinished?.Invoke());
    }

    public float GetValue()
    {
        return _slider.value;
    }
}
