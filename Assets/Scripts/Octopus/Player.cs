using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator), typeof(PolygonCollider2D))]
public class Player : MonoBehaviour
{
    public event UnityAction Died;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> HealthChanged;
    public event UnityAction Disabled;
    public Vector3 Distance => transform.position;
    public int Score => _score;

    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;
    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private Stats _stats; 

    private int _score;
    private Animator _animator;
    private PolygonCollider2D _collider;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<PolygonCollider2D>();
        _collider.enabled = true;
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
            Died?.Invoke();
        }
        else
        {
            _animator.SetTrigger("Damaged");
        }
    }

    public void AddHealth(int value)
    {
        if (_health < _maxHealth)
        {
            _health += value;
            HealthChanged?.Invoke(_health);
        }
    }

    public void Disable(string animationName)
    {
        _collider.enabled = false;
        _animator.Play(animationName);
        _stats.ChangeMoney(_score);
        Disabled?.Invoke();
    }

    public void AddScore(int value)
    {
        _score += value;
        ScoreChanged?.Invoke(_score);
    }
}
