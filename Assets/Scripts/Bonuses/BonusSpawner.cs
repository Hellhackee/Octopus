using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private Bonus[] _bonuses;
    [SerializeField] private BonusSpawnPoint[] _spawnPoints;
    [SerializeField] private float _timeToSpawn;

    private float _elapsedTime = 0;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeToSpawn)
        {
            Spawn();
            _elapsedTime = 0;
        }
    }

    private void Spawn()
    {
        BonusSpawnPoint spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        Vector3 screenPos = _camera.WorldToViewportPoint(spawnPoint.transform.position);

        if (spawnPoint.IsBusy == false && (screenPos.x < -1 || screenPos.x > 1))
        {
            Bonus bonusPrefab = _bonuses[Random.Range(0, _bonuses.Length)];
            Bonus bonusToSpawn = Instantiate(bonusPrefab, transform);

            bonusToSpawn.transform.position = spawnPoint.transform.position;
            spawnPoint.IsBusy = true;
        }
    }
}
