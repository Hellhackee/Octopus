using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private float _maxX;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minX;
    [SerializeField] private float _minY;
    [SerializeField] private int _pointsOnSide;
    [SerializeField] private Player _player;

    private float _elapsedTime = 0f;
    private List<Vector3> _positionsToSpawn = new List<Vector3>();

    private void Start()
    {
        CreateSpawnPoints(_maxX, 0f);
        CreateSpawnPoints(_minX, 0f);
        CreateSpawnPoints(0f, _minY);
        CreateSpawnPoints(0f, _maxY);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeBetweenSpawn)
        {
            _elapsedTime = 0;

            Vector3 position = _positionsToSpawn[Random.Range(0, _positionsToSpawn.Count)];

            Enemy enemy = Instantiate(_enemyPrefab, transform);
            enemy.transform.position = position;
            enemy.SetDirection(_player.Distance);
        }
    }

    private void CreateSpawnPoints(float constantX, float constantY)
    {
        for (int i = 0; i < _pointsOnSide; i++)
        {
            Vector3 spawnPoint = Vector3.zero;

            if (constantX != 0f)
            {
                spawnPoint = new Vector3(constantX, Random.Range(_minY, _maxY), transform.position.z);
            }
            else if (constantY != 0f)
            {
                spawnPoint = new Vector3(Random.Range(_minX, _maxX), constantY, transform.position.z);
            }

            _positionsToSpawn.Add(spawnPoint);
        }
    }
}
