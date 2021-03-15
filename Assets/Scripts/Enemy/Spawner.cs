using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemyPrefabs;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private float _capacity;
    [SerializeField] private float _maxX;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minX;
    [SerializeField] private float _minY;
    [SerializeField] private int _pointsOnSide;
    [SerializeField] private Player _player;

    private float _elapsedTime = 0f;
    private List<Vector3> _positionsToSpawn = new List<Vector3>();
    private List<Enemy> _enemies = new List<Enemy>();

    private void Start()
    {
        CreateSpawnPoints(_maxX);
        CreateSpawnPoints(_minX);
        FillEnemies();
    }

    private void Update()
    {
        
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeBetweenSpawn)
        {
            _elapsedTime = 0;

            Vector3 position = _positionsToSpawn[Random.Range(0, _positionsToSpawn.Count)];

            if (TryGetEnemy(out Enemy enemy))
            {
                enemy.transform.position = position;
                enemy.SetDirection(_player.Distance);

                if (position.x == -10)
                {
                    enemy.transform.rotation = new Quaternion(0, 180f, 0, 0);
                }

                else
                {
                    enemy.transform.rotation = Quaternion.identity;
                }

                enemy.gameObject.SetActive(true);
            }
        }
    }

    private void CreateSpawnPoints(float positionX)
    {
        for (int i = 0; i < _pointsOnSide; i++)
        {
            Vector3 spawnPoint = new Vector3(positionX, Random.Range(_minY, _maxY), transform.position.z);
            _positionsToSpawn.Add(spawnPoint);
        }
    }

    private void FillEnemies()
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)], transform);
            enemy.gameObject.SetActive(false);
            _enemies.Add(enemy);
        }
    }

    private bool TryGetEnemy(out Enemy enemy)
    {
        enemy = _enemies.FirstOrDefault(e => e.gameObject.activeSelf == false);
        return enemy != null;
    }
}
