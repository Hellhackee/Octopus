using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(CircleCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField]private float _speed;
    [SerializeField] private float _dieScaleMin;
    [SerializeField] private float _dieScaleMax;
    [SerializeField] private float _dieAlpha;

    private Vector3 _direction;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider2D;
    private Color _dieColor = new Color(Color.gray.r, Color.gray.g, Color.gray.b, 0.2f);

    private void OnValidate()
    {
        if (_dieScaleMax < _dieScaleMin)
        {
            _dieScaleMax = _dieScaleMin;
        }
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        _rigidbody2D.velocity = _direction * _speed;
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

        _spriteRenderer.DOColor(_dieColor, 1f);
        transform.DOScale(dieScale, 1f);
        _direction = Vector2.up;
        _circleCollider2D.enabled = false;
    }
}
