using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class EnemySpawner 
{
    public event Action<Enemy> EnemySpawned;

    private EnemyConfig _config;
    EnemyFactory _enemyFactory;
    private List<Vector3> _spawnPoints;
    private float _spawnTime;
    private MonoBehaviour _corutineRunner;

    private bool _isSpawning;

    public EnemySpawner(EnemyConfig config,MonoBehaviour corutineRunner)
    {
        _config = config;
        _spawnPoints = config.SpawnPoints;
        _spawnTime = config.TimeToSpawn;
        _corutineRunner = corutineRunner;
        _enemyFactory = new();
    }

    public void Start()
    {
        if (_isSpawning == false)
            _corutineRunner.StartCoroutine(Spawn(_spawnPoints[Random.Range(0,_spawnPoints.Count)]));
    }

    public void Stop()
    {
        _corutineRunner.StopAllCoroutines();
        _isSpawning = false;
    }

    private IEnumerator Spawn(Vector3 position)
    {
        _isSpawning = true;
        
        Enemy enemy = _enemyFactory.Create(_config,position);
        EnemySpawned?.Invoke(enemy);
        yield return new WaitForSeconds(_spawnTime);
        _isSpawning =false;
        Start();
    }
}
