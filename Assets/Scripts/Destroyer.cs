using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Stats _stats;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.IsDead = false;
            enemy.gameObject.SetActive(false);
            _stats.EnemyDodged();
        }

        if (collision.TryGetComponent<Ink>(out Ink ink))
        {
            Destroy(collision.gameObject);
        }
    }
}
