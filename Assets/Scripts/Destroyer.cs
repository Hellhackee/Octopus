using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Stats _stats;
    [SerializeField] private Player _player;

    private bool _playerDisabled = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_playerDisabled == false)
        {
            if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            {
                if (enemy.IsDead == false)
                {
                    enemy.IsDead = false;
                    enemy.gameObject.SetActive(false);
                    _stats.EnemyDodged();
                }
            }

            if (collision.TryGetComponent<Ink>(out Ink ink))
            {
                Destroy(collision.gameObject);
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
