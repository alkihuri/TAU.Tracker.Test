using System.Collections.Generic;
using UnityEditor;

public class TowerOfLondonDomainLogic : IGameLogic  
{
    public int MaxMoves { get; private set; }
    public int CurrentMoves { get; private set; }

    public List<List<int>> CurrentConfiguration { get; private set; } // Текущее состояние основ
    public List<List<int>> TargetConfiguration { get; private set; } // Целевое состояние

    public TowerOfLondonDomainLogic(int maxMoves, List<List<int>> targetConfiguration)
    {
        MaxMoves = maxMoves;
        CurrentMoves = 0;
        TargetConfiguration = targetConfiguration;
        CurrentConfiguration = new List<List<int>> { new List<int>(), new List<int>(), new List<int>() };
    }

    public bool TryMoveRing(int fromPeg, int toPeg)
    {
        var fromPegRings = CurrentConfiguration[fromPeg];
        var toPegRings = CurrentConfiguration[toPeg];

        if (fromPegRings.Count == 0) return false; // Нет колец для перемещения
        if (toPegRings.Count > 0 && toPegRings[0] < fromPegRings[0]) return false; // Нельзя положить большое кольцо на маленькое

        int ring = fromPegRings[0];
        fromPegRings.RemoveAt(0);
        toPegRings.Insert(0, ring);

        CurrentMoves++;
        return true;
    }

    public bool IsWin()
    {
        return CurrentConfiguration.Equals(TargetConfiguration);
    }

    public bool IsLose()
    {
        return CurrentMoves >= MaxMoves;
    }
}
