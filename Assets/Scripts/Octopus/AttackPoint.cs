using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;

    public Vector3 Direction => _direction;
}
