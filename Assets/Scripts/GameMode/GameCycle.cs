using System;
using UnityEngine;

public class GameCycle :IDisposable
{
    private GameMode _gameMode;
    private PlayerSpawner _playerSpawner;
    private Player _player;

    private PlayerConfig _playerConfig;
    private EnemyConfig _enemyConfig;
    private LevelConfig _levelConfig;

    private IWinningCondition _winningCondition;
    private IDefeatCondition _defeatCondition;

    public void Start(TargetFollower mainCamera, GameModeDefeatType defeatType, GameModeWinType winType, MonoBehaviour corutineRunner)
    {
        LoadConfigs();
        SetPlayer(mainCamera);

        _gameMode = new(_levelConfig,_enemyConfig);
        SetLevelConditions(defeatType, winType);

        _gameMode.SetConditions(_winningCondition, _defeatCondition);
        _gameMode.Start(corutineRunner);
        
        _gameMode.Win += Win;
        _gameMode.Defeat += Defeat;
    }

    public void Stop()
    {
        _gameMode.Stop();

        _gameMode.Win -= Win;
        _gameMode.Defeat -= Defeat;
    }

    public void Update(float deltaTime)
    {
        _gameMode.Update(deltaTime);
    }

    private void SetPlayer(TargetFollower mainCamera)
    {
        _playerSpawner = new PlayerSpawner();
        _player = _playerSpawner.Spawn(_playerConfig, _levelConfig.PlayerStartPosition);
        mainCamera.Initialize(_player.transform);
    }

    private void LoadConfigs()
    {
        _playerConfig = Resources.Load<PlayerConfig>("Configs/PlayerConfig");
        _enemyConfig = Resources.Load<EnemyConfig>("Configs/EnemyConfig");
        _levelConfig = Resources.Load<LevelConfig>("Configs/LevelConfig");
    }

    private void SetLevelConditions (GameModeDefeatType defeatType, GameModeWinType winType)
    {
        switch (defeatType)
        {
            case GameModeDefeatType.Death:
                _defeatCondition = new PlayerDeathDefeatCondition(_player);
                break;

            case GameModeDefeatType.OutOfEnemies:
                _defeatCondition = new OutOfEnemiesDefeatCondition(_levelConfig.MaxSpawnedEnemies, _gameMode.EnemyCounter);
                break;
        }

        switch (winType)
        {
            case GameModeWinType.OutOfTime:
                _winningCondition = new OutOfTimeWinCondition(_levelConfig.TimeToWin);
                break;

            case GameModeWinType.KillEnemies:
                _winningCondition = new KilledenemiesWinCondition(_levelConfig.KilledEnemiesCountToWin,_gameMode.EnemyCounter);
                break;
        }
    }

    private void Win()
    {
        Debug.Log("Win");
        Stop();
    }
    private void Defeat()
    {
        Debug.Log("Defeat");
        Stop();
    }
    public void Dispose() => Stop();
}
