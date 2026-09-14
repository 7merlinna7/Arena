using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private EnemyConfig _enemyConfig;

    private PlayerSpawner _playerSpawner;
    private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _playerSpawner = new PlayerSpawner(_playerConfig);
        _playerSpawner.Spawn(Vector3.zero);

        _enemySpawner = new EnemySpawner(_enemyConfig,this);
        _enemySpawner.Start();
    }
}
