using System;

public interface IReadOnlyEnemyCounter 
{
    public event Action<int> EnemiesKilled;
    public int EnemyCount {  get; }

}
