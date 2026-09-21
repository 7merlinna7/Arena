using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private TargetFollower _mainCamera;
    [SerializeField] private GameModDefeatType _DefeatType;
    [SerializeField] private GameModeWinType _WinType;

    private GameCycle _gameCycle;

    private void Awake()
    {
        _gameCycle = new GameCycle();
        _gameCycle.Start(_mainCamera,_DefeatType,_WinType,this);
    }

    private void Update()
    {
        _gameCycle.Update(Time.deltaTime);
    }
}
