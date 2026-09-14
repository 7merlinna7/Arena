using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/EnemyConfig", fileName = "EnemyConfig")]

public class EnemyConfig : ScriptableObject
{
    [field: SerializeField] public Enemy Prefab { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; } = 15;
    [field: SerializeField] public float RotationSpeed { get; private set; } = 800;
    [field: SerializeField] public float TimeToChangeDirection { get; private set; } = 1f;
    [field: SerializeField] public float TimeToSpawn { get; private set; } = 1f;
    [field: SerializeField] public List<Vector3> SpawnPoints { get; private set; } 
}
