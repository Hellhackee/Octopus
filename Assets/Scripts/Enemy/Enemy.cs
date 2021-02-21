using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(PolygonCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField]private float _speed;
    [SerializeField] private float _dieScaleMin;
    [SerializeField] private float _dieScaleMax;
    [SerializeField] private float _dieAlpha;
    [SerializeField] private ParticleSystem _particleSystem;
    
    private Player _player;
    private Vector3 _direction;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private PolygonCollider2D _collider;
    private Color _dieColor = new Color(Color.gray.r, Color.gray.g, Color.gray.b, 0.2f);

    private void OnValidate()
    {
        if (_dieScaleMax < _dieScaleMin)
        {
            _dieScaleMax = _dieScaleMin;
        }
    }

    private void Awake()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        _rigidbody2D.velocity = _direction * _speed;
        var direction = _player.transform.position;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ink>())
        {
            DieByInk();
        }

        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.GetDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = (direction - transform.position).normalized;
    }

    private void DieByInk()
    {
        float dieScale = Random.Range(_dieScaleMin, _dieScaleMax);

        _particleSystem.Play();
        _spriteRenderer.DOColor(_dieColor, 1f);
        transform.DOScale(dieScale, 1f);
        _direction = Vector2.up;
        _collider.enabled = false;
    }
}
