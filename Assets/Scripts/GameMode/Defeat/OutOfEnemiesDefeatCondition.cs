using System;

public class OutOfEnemiesDefeatCondition : IDefeatCondition
{
    public event Action Defeat;

    private int _maxSpawnedEnemies;
    private EnemyCounter _enemyCounter;

    public OutOfEnemiesDefeatCondition(int maxSpawnedEnemies, EnemyCounter enemyCounter)
    {
        _maxSpawnedEnemies = maxSpawnedEnemies;
        _enemyCounter = enemyCounter;
    }

    public void Update()
    {
        if(_enemyCounter.EnemyCount > _maxSpawnedEnemies)
            Defeat?.Invoke();
    }
}
