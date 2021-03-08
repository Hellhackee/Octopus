using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Bonus : MonoBehaviour
{
    abstract protected void UseEffect(Player player);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            UseEffect(player);
        }
    }
}
