using System;

public interface IWinningCondition 
{
    public event Action Win;
    public void Update(float deltaTime);
}
