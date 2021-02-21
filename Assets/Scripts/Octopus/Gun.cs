using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Gun : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private AttackPoint _point;
    [SerializeField] private float _timeForGunBusy;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _point.IsReloading += ReloadGun;
    }

    private void OnDisable()
    {
        _point.IsReloading -= ReloadGun;
    }

    private void ReloadGun()
    {
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        _point.IsBusy = true;
        _animator.Play("ReloadGun");
        yield return new WaitForSeconds(_timeForGunBusy);

        _point.IsBusy = false;
    }
}
