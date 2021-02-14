using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField]private float _speed;

    private Vector3 _direction;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody2D.velocity = _direction * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ink>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
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
}
