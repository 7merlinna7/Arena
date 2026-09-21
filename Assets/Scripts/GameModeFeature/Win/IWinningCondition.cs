using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWinningCondition 
{
    public event Action Win;
    public void Update(float deltaTime);
}
