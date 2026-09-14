using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerBootstrap 
{
    private PlayerInput _playerInput;
    private Player _player;

    public void StartPlayer(GameObject playerGameObject,PlayerConfig playerConfig)
    {
        PlayerConfig config = playerConfig;

        _player = playerGameObject.GetComponent<Player>();
        _playerInput = playerGameObject.GetComponent<PlayerInput>();

        Rotator rotator = new Rotator(config.RotationSpeed, playerGameObject.transform);
        Mover mover = new Mover(config.MoveSpeed, playerGameObject.transform);

        _player.Initialize(mover,rotator);
        _playerInput.Initialize(_player);
    }
}
