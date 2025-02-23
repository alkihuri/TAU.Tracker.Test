using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class RingsConfiguration
{
    public List<List<int>> Configuration = new List<List<int>>();

    public RingsConfiguration(List<List<int>> configuration)
    {
        Configuration = configuration;
    }

    public bool IsValid()
    {
        foreach (var peg in Configuration)
        {
            for (int i = 1; i < peg.Count; i++)
            {
                if (peg[i] >= peg[i - 1])
                    return false; // Кольца должны быть упорядочены по убыванию
            }
        }
        return true;
    }
}

[System.Serializable]
public class TowerOfLondonDomainLogic : IGameLogic
{
    public int MaxMoves { get; private set; }
    public int CurrentMoves { get; private set; }

    public RingsConfiguration CurrentConfiguration { get; private set; } // Текущее состояние основ
    public RingsConfiguration TargetConfiguration { get; private set; } // Целевое состояние

    public TowerOfLondonDomainLogic(int maxMoves, RingsConfiguration targetConfiguration)
    {
        MaxMoves = maxMoves;
        CurrentMoves = 0;
        TargetConfiguration = targetConfiguration;

        // Начальная конфигурация: все кольца на первой основе
        CurrentConfiguration = new RingsConfiguration(new List<List<int>>
        {
            new List<int> { 3, 2, 1 }, // Первая основа
            new List<int>(),            // Вторая основа
            new List<int>()             // Третья основа
        });
    }

    public bool TryMoveRing(int fromPeg, int toPeg)
    {
        if (fromPeg < 0 || fromPeg >= CurrentConfiguration.Configuration.Count ||
            toPeg < 0 || toPeg >= CurrentConfiguration.Configuration.Count)
        {
            Debug.LogError("Некорректный индекс основы");
            return false;
        }

        var fromPegRings = CurrentConfiguration.Configuration[fromPeg];
        var toPegRings = CurrentConfiguration.Configuration[toPeg];

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
        for (int i = 0; i < CurrentConfiguration.Configuration.Count; i++)
        {
            if (!CurrentConfiguration.Configuration[i].SequenceEqual(TargetConfiguration.Configuration[i]))
                return false;
        }
        return true;
    }

    public bool IsLose()
    {
        return CurrentMoves >= MaxMoves;
    }

    public RingsConfiguration GetCurrentConfiguration() => CurrentConfiguration;

    public RingsConfiguration GetTargetConfiguration() => TargetConfiguration;
}