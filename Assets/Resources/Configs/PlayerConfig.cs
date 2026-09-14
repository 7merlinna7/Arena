using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/PlayerConfig",fileName = "PlayerConfig")]

public class PlayerConfig : ScriptableObject
{
    [field: SerializeField] public Player Prefab { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; } =15;
    [field: SerializeField] public float RotationSpeed { get; private set; } = 800;

}
