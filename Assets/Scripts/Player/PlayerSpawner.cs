using UnityEngine;

public class PlayerSpawner
{
    private PlayerConfig _config;


    public PlayerSpawner(PlayerConfig config)
    {
        _config = config;
    }

    public GameObject Spawn(Vector3 position)
    {
        GameObject instance = Object.Instantiate(_config.Prefab.gameObject, position, Quaternion.identity, null);

        PlayerBootstrap playerBootstrap = new PlayerBootstrap();
        playerBootstrap.StartPlayer(instance, _config);

        return instance;
    }
}
