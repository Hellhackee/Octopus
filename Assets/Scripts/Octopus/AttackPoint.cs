using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private Player _player;

    public Vector3 Direction => _direction;
    public bool IsBusy;
    public event UnityAction IsReloading;

    public void ReloadGun()
    {
        IsReloading?.Invoke();
    }
}
