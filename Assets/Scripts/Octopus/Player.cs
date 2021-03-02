using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction PlayerDied;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> HealthChanged;
    public Vector3 Distance => transform.position;

    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;
    [SerializeField] private float _speed;
    [SerializeField] private int _health;

    private int _score;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    private void Update()
    {
        Vector3 _cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _cursorPosition.z = transform.position.z;

        if (_cursorPosition.x < _minX)
            _cursorPosition.x = _minX;

        if (_cursorPosition.x > _maxX)
            _cursorPosition.x = _maxX;

        if (_cursorPosition.y > _maxY)
            _cursorPosition.y = _maxY;

        if (_cursorPosition.y < _minY)
            _cursorPosition.y = _minY;

        Vector3 position = Vector3.Lerp(transform.position, _cursorPosition, _speed * Time.deltaTime);        
        transform.position = position;
    }

    public void GetDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
        
        if (_health <= 0)
        {
            PlayerDied?.Invoke();
            Die();
        }
    }

    private void Die()
    {
        Destroy(this);
    }

    public void AddScore(int value)
    {
        _score += value;
        ScoreChanged?.Invoke(_score);
    }
}
