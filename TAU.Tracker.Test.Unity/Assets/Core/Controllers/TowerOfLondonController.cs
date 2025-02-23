using System;
using System.Diagnostics;

public class TowerOfLondonController
{
    public TowerOfLondonDomainLogic Domain { get; private set; }
    public Action OnStateChanged; // Уведомление об изменении состояния
    public Action OnMovesChanged; // Уведомление об изменении количества ходов

    public TowerOfLondonController(TowerOfLondonDomainLogic model)
    {
        Domain = model;
    }

    public void MoveRing(int fromPeg, int toPeg)
    {
        if (Domain.TryMoveRing(fromPeg, toPeg))
        {
            OnMovesChanged?.Invoke();
            OnStateChanged?.Invoke();
        }
        else
        {
            UnityEngine.Debug.Log("Ошибка при перемещении.");
        }
    }
}