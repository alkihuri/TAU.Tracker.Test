using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class TowerOfLondonDomainLogic : IGameLogic
{
    public int MaxMoves { get; private set; }
    public int CurrentMoves { get; private set; }

    public RingsConfiguration CurrentConfiguration;   // Текущее состояние основ
    public RingsConfiguration TargetConfiguration; // Целевое состояние

    public TowerOfLondonDomainLogic(int maxMoves, RingsConfiguration targetConfiguration)
    {
        MaxMoves = maxMoves;
        CurrentMoves = 0;
        TargetConfiguration = targetConfiguration;

        // Начальная конфигурация: все кольца на первой основе
        CurrentConfiguration = new RingsConfiguration(new List<List<int>>
        {
            new List<int> {1,0,0}, // Первая основа
            new List<int> {2,0,0},  // Вторая основа
            new List<int> {3,0,0}   // Третья основа
        });
    }

    public bool TryMoveRing(int fromPeg, int toPeg, int size)
    {
        // Проверка на null
        if (CurrentConfiguration == null || TargetConfiguration == null)
        {
            Debug.LogError("Конфигурация не инициализирована");
            return false;
        }

        // Проверка корректности индексов
        if (!IsPegIndexValid(fromPeg) || !IsPegIndexValid(toPeg))
        {
            Debug.LogError($"Некорректный индекс основы: from {fromPeg} to {toPeg}");
            return false;
        }

        // Получаем кольца на основах
        var fromPegRings = CurrentConfiguration.Configuration[fromPeg - 1];
        var toPegRings = CurrentConfiguration.Configuration[toPeg - 1];

        //// Проверка возможности перемещения
        //if (!CanMoveRing(fromPegRings, toPegRings))
        //{
        //    Debug.Log("Невозможно переместить кольцо");
        //    return false;
        //}

        // Перемещаем кольцо
        MoveRing(fromPegRings, toPegRings);

        // Увеличиваем счетчик ходов
        CurrentMoves++;

        // Проверяем победу или поражение
        CheckGameState();

        return true;
    }

    private bool IsPegIndexValid(int pegIndex)
    {
        return pegIndex > 0 && pegIndex <= CurrentConfiguration.Configuration.Count;
    }

    private bool CanMoveRing(List<int> fromPegRings, List<int> toPegRings)
    {
        // Нет колец для перемещения
        if (fromPegRings.Count == 0)
        {
            return false;
        }

        // Нельзя положить большое кольцо на маленькое
        if (toPegRings.Count > 0 && toPegRings[0] < fromPegRings[0])
        {
            return false;
        }

        return true;
    }

    private void MoveRing(List<int> fromPegRings, List<int> toPegRings)
    {
        // Удаляем кольцо из исходной основы
        int ring = fromPegRings[0];
        fromPegRings.Remove(ring);

        // Добавляем кольцо в целевую основу
        toPegRings.Insert(0,ring);
    }

    private void CheckGameState()
    {
        if (IsWin())
        {
            Debug.Log("Победа!");
        }
        else if (IsLose())
        {
            Debug.Log("Поражение!");
        }
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