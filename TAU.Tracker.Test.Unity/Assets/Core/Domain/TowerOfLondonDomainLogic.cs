using System.Collections.Generic;

public class TowerOfLondonDomainLogic
{
    public enum GameState { Playing, Win, Lose }
    public GameState CurrentState { get; private set; }

    public int MaxMoves { get; private set; }
    public int CurrentMoves { get; private set; }

    public List<List<int>> CurrentConfiguration { get; private set; } // Текущее состояние основ
    public List<List<int>> TargetConfiguration { get; private set; } // Целевое состояние

    public TowerOfLondonDomainLogic(int maxMoves, List<List<int>> targetConfiguration)
    {
        MaxMoves = maxMoves;
        CurrentMoves = 0;
        CurrentState = GameState.Playing;
        TargetConfiguration = targetConfiguration;
        CurrentConfiguration = new List<List<int>> { new List<int>(), new List<int>(), new List<int>() };
    }

    public bool TryMoveRing(int fromPeg, int toPeg)
    {
        if (CurrentState != GameState.Playing) return false;

        var fromPegRings = CurrentConfiguration[fromPeg];
        var toPegRings = CurrentConfiguration[toPeg];

        if (fromPegRings.Count == 0) return false; // Нет колец для перемещения
        if (toPegRings.Count > 0 && toPegRings[0] < fromPegRings[0]) return false; // Нельзя положить большое кольцо на маленькое

        int ring = fromPegRings[0];
        fromPegRings.RemoveAt(0);
        toPegRings.Insert(0, ring);

        CurrentMoves++;
        CheckWinCondition();
        return true;
    }

    private void CheckWinCondition()
    {
        if (CurrentConfiguration.Equals(TargetConfiguration))
        {
            CurrentState = GameState.Win;
        }
        else if (CurrentMoves >= MaxMoves)
        {
            CurrentState = GameState.Lose;
        }
    }
}