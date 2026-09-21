using System;

public interface IDefeatCondition 
{
    public event Action Defeat;
    public void Update();
}
