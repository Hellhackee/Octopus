using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyFish>(out EnemyFish enemy))
        {
            enemy.IsDead = false;
            enemy.gameObject.SetActive(false);
        }

        if (collision.TryGetComponent<Ink>(out Ink ink))
        {
            Destroy(collision.gameObject);
        }
    }
}
