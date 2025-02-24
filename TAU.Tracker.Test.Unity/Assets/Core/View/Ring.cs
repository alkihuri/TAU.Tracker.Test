using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public int Size;  // Размер кольца (1 - маленькое, 2 - среднее, 3 - большое)
    public int CurrentPegIndex; // Индекс основы, на которой находится кольцо

    public RingAnchor CurrentAnchor { get; private set; }

    public Transform visual; // Визуальное представление кольца 
    private Vector3 _lastFixedPosition;

    public void Initialize(int size, int pegIndex)
    {
        if (visual == null)
            visual = transform.GetChild(0); // Получаем визуальное представление кольца (первый дочерний объект)
        if (visual == null)
        {
            Debug.LogError("Visual не найден");
            return;
        }
        Size = size;
        CurrentPegIndex = pegIndex;
        UpdateVisual();
    }

    public void Highlite()
    {
        // Логика подсветки кольца
        Renderer renderer = visual.GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.yellow; // Пример: подсветка кольца
        }
        _lastFixedPosition = transform.position;
    }


    private void UpdateVisual()
    {
        // Логика обновления визуального представления кольца
        if (Size != 0)
            visual.localScale = new Vector3(Size, 1, Size); // Пример: размер кольца зависит от его "размера"
        Renderer renderer = visual.GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.Lerp(Color.red, Color.green, Size / 3f); // Пример: цвет кольца зависит от его "размера"
        }
        if (CurrentAnchor != null)
            transform.position = CurrentAnchor.Position;
        else
            Debug.LogError("CurrentAnchor is null");
    }

    public void ResetHighlight()
    {
        // Логика снятия подсветки с кольца
        Renderer renderer = visual.GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.white; // Пример: снятие подсветки с кольца
        }

    }

    public void ResetPosition()
    {
        UpdateVisual();
    }

    public void SetAtAnchor(RingAnchor anchor)
    {
        transform.SetParent(anchor.transform);
        CurrentPegIndex = anchor.Index;
        CurrentAnchor = anchor;
        UpdateVisual();
    }
}