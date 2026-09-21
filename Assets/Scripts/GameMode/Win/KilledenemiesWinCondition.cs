using System;

public class KilledenemiesWinCondition : IWinningCondition, IDisposable
{
    public event Action Win;

    private int _killEnemiesToWin;
    private IReadOnlyEnemyCounter _enemyCounter;
    private int _enemiesKilled;
    public int EnemiesKilled => _enemiesKilled;

    public KilledenemiesWinCondition(int killEnemiesToWin, IReadOnlyEnemyCounter enemyCounter)
    {
        _killEnemiesToWin = killEnemiesToWin;
        _enemyCounter = enemyCounter;
        _enemyCounter.EnemiesKilled += CountKilledEnemies;
    }

    private void CountKilledEnemies(int count) => _enemiesKilled += count;

    public void Update(float deltaTime)
    {
        if (_enemiesKilled > _killEnemiesToWin)
            Win?.Invoke();
    }

    public void Dispose()
    {
        _enemyCounter.EnemiesKilled -= CountKilledEnemies;
    }
}
