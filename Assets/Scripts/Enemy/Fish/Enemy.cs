using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    public bool IsDead = false;
    public event UnityAction<float, float> EnemyDied;

    [SerializeField] private int _damage;
    [SerializeField]private float _speed;
    [SerializeField] private float _dieAlpha;
    [SerializeField] private float _diyngTime;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private int _reward;
    
    private Stats _stats;
    private Player _player;
    private Vector3 _direction;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _player = GameObject.FindObjectOfType<Player>();
        _stats = Camera.main.GetComponent<Stats>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody2D.velocity = _direction * _speed;
        Vector3 direction = _player.transform.position;   
        
        if (IsDead)
        {
            _spriteRenderer.DOFade(_dieAlpha, _diyngTime);
        }
        else
        {
            SetColorA();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsDead == false)
        {
            if (collision.GetComponent<Ink>())
            {
                DieByInk();
                Destroy(collision.gameObject);
            }

            if (collision.TryGetComponent<Player>(out Player player))
            {
                player.GetDamage(_damage);
                gameObject.SetActive(false);
            }
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = (direction - transform.position).normalized; 
    }

    private void DieByInk()
    {
        _stats.EnemyKilled();
        _player.AddScore(_reward);
        _particleSystem.Play();
        IsDead = true;
        EnemyDied?.Invoke(_diyngTime, _dieAlpha);
    }

    private void SetColorA()
    {
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 1f);
    }
}
