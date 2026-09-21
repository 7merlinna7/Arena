public class PlayerBootstrap 
{
    private PlayerInput _playerInput;

    public void StartPlayer(Player player,PlayerConfig playerConfig)
    {
        _playerInput = player.GetComponent<PlayerInput>();
        Shooter shooter = player.GetComponentInChildren<Shooter>();

        Rotator rotator = new Rotator(playerConfig.RotationSpeed, player.transform);
        Mover mover = new Mover(playerConfig.MoveSpeed, player.transform);
        Health health = new Health(playerConfig.MaxHealth);

        player.Initialize(mover,rotator,shooter,health);
        _playerInput.Initialize(player);
    }
}
