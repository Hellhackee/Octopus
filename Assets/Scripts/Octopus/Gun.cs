using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gun : MonoBehaviour
{
    [SerializeField] private AttackPoint _point;
    [SerializeField] private float _timeForGunBusy;
    
    private bool _needReload = false;

    private void Update()
    {
        if(_needReload)
        {
            transform.DORotate(new Vector3(0, 0, 360f), 1f, RotateMode.FastBeyond360);
        }
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
        _needReload = true;
        yield return new WaitForSeconds(_timeForGunBusy);

        _point.IsBusy = false;
        _needReload = false;
    }
}
