using UnityEngine;

public class EnemyFactory 
{
    public Enemy Create(EnemyConfig enemyConfig, Vector3 spawnposition)
    {
        Enemy instance = Object.Instantiate(enemyConfig.Prefab, spawnposition, Quaternion.identity, null);

        Rotator rotator = new Rotator(enemyConfig.RotationSpeed, instance.transform);
        Mover mover = new Mover(enemyConfig.MoveSpeed, instance.transform);
        Health health = new Health(enemyConfig.Health);

        instance.Initialize(mover, rotator,health, enemyConfig.TimeToChangeDirection, enemyConfig.Damage);

        return instance;
    }

}
