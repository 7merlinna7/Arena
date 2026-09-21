using System;

public class OutOfEnemiesDefeatCondition : IDefeatCondition
{
    public event Action Defeat;

    private int _maxSpawnedEnemies;
    private IReadOnlyEnemyCounter _enemyCounter;

    public OutOfEnemiesDefeatCondition(int maxSpawnedEnemies, IReadOnlyEnemyCounter enemyCounter)
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
