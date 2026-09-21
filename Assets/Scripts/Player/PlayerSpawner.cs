using UnityEngine;

public class PlayerSpawner
{
    public Player Spawn(PlayerConfig config, Vector3 position)
    {
        Player player = Object.Instantiate(config.Prefab, position, Quaternion.identity, null);
        PlayerBootstrap playerBootstrap = new PlayerBootstrap();
        playerBootstrap.StartPlayer(player, config);

        return player;
    }
}
