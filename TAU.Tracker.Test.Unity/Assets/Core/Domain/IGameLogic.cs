using System.Collections.Generic;

public interface IGameLogic
{
    public RingsConfiguration GetCurrentConfiguration();
    public RingsConfiguration GetTargetConfiguration();
}