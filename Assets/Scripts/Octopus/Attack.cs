﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private AttackPoint[] _points;
    [SerializeField] private float _cooldown;
    [SerializeField] private Ink _ink;
    [SerializeField] private Transform _container;
    [SerializeField] private float _timeToReload;
    [SerializeField] private Player _player;
    [SerializeField] private ProgressBar _progressBar;

    private bool _playerDisabled = false;    
    private float _elapsedTime = 0f;
    private float _elapsedTimeForReload = 0f;

    private void Update()
    {
        if (_playerDisabled == false)
        {
            _elapsedTime += Time.deltaTime;
            _elapsedTimeForReload += Time.deltaTime;

            if (_elapsedTime >= _cooldown)
            {
                _elapsedTime = 0;

                foreach (AttackPoint point in _points)
                {
                    if (point.IsBusy == false)
                    {
                        Ink ink = Instantiate(_ink, _container);
                        ink.transform.position = point.transform.position;
                        ink.SetDirection(point.Direction);
                    }
                }
            }

            if (_elapsedTimeForReload >= _timeToReload)
            {
                _elapsedTimeForReload = 0f;
                AttackPoint point = _points[Random.Range(0, _points.Length)];
                point.ReloadGun();
            }
        }
    }

    private void OnEnable()
    {
        _player.Disabled += OnPlayerDisabled;
    }

    private void OnDisable()
    {
        _player.Disabled -= OnPlayerDisabled;
    }

    private void OnPlayerDisabled()
    {
        _playerDisabled = true;
    }
}
