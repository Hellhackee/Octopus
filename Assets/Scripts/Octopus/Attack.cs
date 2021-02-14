using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private AttackPoint[] _points;
    [SerializeField] private float _cooldown;
    [SerializeField] private Ink _ink;
    [SerializeField] private Transform _container;

    private float _elapsedTime = 0f;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _cooldown)
        {
            _elapsedTime = 0;

            foreach (AttackPoint point in _points)
            {
                Ink ink = Instantiate(_ink, _container);
                ink.transform.position = point.transform.position;
                ink.SetDirection(point.Direction);
            }
        }
    }
}
