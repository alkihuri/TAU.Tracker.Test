using System;
using System.Diagnostics;

public class DIContainer
{
    /// всякая инфа для инжекта 
    public IGameLogic GameLogic;

    public void Register<T>(T logic)
    {
        if (typeof(T) == typeof(IGameLogic)) // если это интерфейс IGameLogic времени не было тупо захардкодил :(
        {
            GameLogic = logic as IGameLogic;
            UnityEngine.Debug.Log("Зарегистрирован GameLogic для стандартной игры");
        }
    }
}
