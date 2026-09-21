using System;

public class PlayerDeathDefeatCondition : IDefeatCondition
{
    public event Action Defeat;
    IDeadBehaviour _deadBehaviour;

    public PlayerDeathDefeatCondition(IDeadBehaviour deadBehaviour)
    {
        _deadBehaviour = deadBehaviour;
    }

    public void Update()
    { 
        if(_deadBehaviour.IsDead)
        Defeat?.Invoke();
    }
}
