using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner 
{
    private EnemyConfig _config;
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
    }

    public void Start()
    {

        if (_isSpawning == false)
            _corutineRunner.StartCoroutine(Spawn(_spawnPoints[Random.Range(0,_spawnPoints.Count)]));
    }



    private IEnumerator Spawn(Vector3 position)
    {
        _isSpawning = true;
        GameObject instance = Object.Instantiate(_config.Prefab.gameObject, position, Quaternion.identity, null);
        EnemyBootstrap playerBootstrap = new EnemyBootstrap();
        playerBootstrap.StartEnemy(instance, _config);
        yield return new WaitForSeconds(_spawnTime);
        _isSpawning =false;
        Start();
    }
}
