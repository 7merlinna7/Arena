using System;

public class OutOfTimeWinCondition : IWinningCondition
{
    public event Action Win;

    private float _timeToWin;
    private float _time;
    public OutOfTimeWinCondition(float timeToWin)
    {
        _timeToWin = timeToWin;
        _time = timeToWin;
    }

    public void Update (float deltaTime)
    {
        if (_time == 0)
            return;

        _time -= deltaTime;

        if (_timeToWin <= 0)
        {
            _time = 0;
            Win?.Invoke();
        }
    }

    public void ResetTimer() => _time = _timeToWin;
}
