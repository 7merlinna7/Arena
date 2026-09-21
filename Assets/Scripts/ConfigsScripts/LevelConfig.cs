using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/LevelConfig", fileName = "LevelConfig")]

public class LevelConfig : ScriptableObject
{
    [field: SerializeField] public Vector3 PlayerStartPosition { get; private set; }
    [field: SerializeField] public float TimeToWin { get; private set; } = 15;
    [field: SerializeField] public int MaxSpawnedEnemies { get; private set; } = 15;
    [field: SerializeField] public int KilledEnemiesCountToWin { get; private set; } = 5;
    [field: SerializeField] public float TimeToSpawnEnemy { get; private set; } = 1f;

    [ContextMenu("UpdateStartPlayerPosition")]
    private void UpdateStartPlayerPosition()
    {
        GameObject point = GameObject.FindGameObjectWithTag("PlayerSpawner");
        PlayerStartPosition = point.transform.position;
    }
}
