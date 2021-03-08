using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Bonus
{
    [SerializeField] private int _healthAward;

    protected override void UseEffect(Player player)
    {
        player.AddHealth(_healthAward);
        Destroy(gameObject);
    }
}
