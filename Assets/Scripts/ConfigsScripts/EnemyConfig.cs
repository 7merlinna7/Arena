using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/EnemyConfig", fileName = "EnemyConfig")]

public class EnemyConfig : ScriptableObject
{
    [field: SerializeField] public Enemy Prefab { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; } = 15;
    [field: SerializeField] public float RotationSpeed { get; private set; } = 800;
    [field: SerializeField] public float TimeToChangeDirection { get; private set; } = 1f;
    [field: SerializeField] public int Damage { get; private set; } = 10;
    [field: SerializeField] public int Health { get; private set; } = 10;

    [field: SerializeField] public List<Vector3> SpawnPoints { get; private set; }

    [ContextMenu("UpdateStartPlayerPosition")]
    private void UpdateEnemySpawnPoints()
    {
        SpawnPoints.Clear();
        GameObject[]points = GameObject.FindGameObjectsWithTag("EnemySpawner");

        foreach (var point in points) 
            SpawnPoints.Add(point.transform.position);
    }
}
