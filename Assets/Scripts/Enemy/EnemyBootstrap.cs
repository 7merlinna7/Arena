using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyBootstrap 
{
    public void StartEnemy(GameObject enemyGameObject, EnemyConfig enemyConfig)
    {
        EnemyConfig config = enemyConfig;

        Enemy enemy = enemyGameObject.GetComponent<Enemy>();

        Rotator rotator = new Rotator(config.RotationSpeed, enemyGameObject.transform);
        Mover mover = new Mover(config.MoveSpeed, enemyGameObject.transform);

        enemy.Initialize(mover, rotator,config.TimeToChangeDirection);
    }

}
