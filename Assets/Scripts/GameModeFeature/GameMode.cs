using System;
using UnityEngine;

public class GameMode 
{
    public event Action Win
    {
        add =>_winningCondition.Win += value;
        remove =>_winningCondition.Win -= value;
    }

    public event Action Defeat
    {
        add => _defeatCondition.Defeat += value;
        remove => _defeatCondition.Defeat -= value;
    }

    private IWinningCondition _winningCondition;
    private IDefeatCondition _defeatCondition;

    private LevelConfig _levelConfig;
    private EnemyConfig _enemyConfig;

    private EnemySpawner _enemySpawner;
    private EnemyCounter _enemyCounter = new();
    public EnemyCounter EnemyCounter => _enemyCounter;

    public GameMode(LevelConfig levelConfig, EnemyConfig enemyConfig)
    {
        _levelConfig = levelConfig;
        _enemyConfig = enemyConfig;
    }

    public void SetConditions(IWinningCondition winningCondition, IDefeatCondition defeatCondition)
    {
        _winningCondition = winningCondition;
        _defeatCondition = defeatCondition;
    }

    public void Start(MonoBehaviour corutineRunner)
    {
        _enemySpawner = new EnemySpawner(_enemyConfig,corutineRunner);
        _enemySpawner.EnemySpawned +=RegisterEnemy;

        _enemySpawner.Start();
    }

    public void Update(float deltaTime)
    {
        _enemyCounter.Update();

        _defeatCondition.Update();
        _winningCondition.Update(deltaTime);
    }

    public void Stop()
    {
        _enemySpawner.Stop();
        _enemyCounter.Stop();
        _enemySpawner.EnemySpawned -= RegisterEnemy;
    }

    private void RegisterEnemy(Enemy enemy) => _enemyCounter.RegisterEnemy(enemy, () => enemy.IsDead); 
}
