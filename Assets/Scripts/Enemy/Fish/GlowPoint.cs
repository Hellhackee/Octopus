using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class GlowPoint : MonoBehaviour
{
    [SerializeField] private EnemyFish _enemyFish;
    [SerializeField] private Light _light;
    [SerializeField] private Color[] _lightColors;
    [SerializeField] private float _maxGlowIntensity;

    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        _enemyFish.OnEnemyDied += OnEnemyDied;
    }

    private void OnDisable()
    {
        _enemyFish.OnEnemyDied -= OnEnemyDied;
        _spriteRenderer.DOFade(1f, 0f);
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _light.color = _lightColors[Random.Range(0, _lightColors.Length)];
        _light.DOIntensity(_maxGlowIntensity, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    private void OnEnemyDied(float dyingTime, float alpha)
    {
        _spriteRenderer.DOFade(alpha, dyingTime);
    }
}
