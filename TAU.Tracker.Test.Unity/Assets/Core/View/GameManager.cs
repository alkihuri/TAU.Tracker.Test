using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TowerOfLondonController Controller;
    List<RingAnchor> ringAnchors = new List<RingAnchor>();
    private void Awake()
    {
        ringAnchors = GetComponentsInChildren<RingAnchor>().ToList();

        for (int i = 0; i < ringAnchors.Count; i++)
        {
            ringAnchors[i].Initialize(i + 1);
        }
    }
    private void Start()
    {
        // Подписка на изменения
        Controller.OnStateChanged += UpdateView;
        Controller.OnMovesChanged += UpdateMoves;
    }

    private void UpdateView()
    {
        // Обновление визуального состояния игры 
    }

    private void UpdateMoves()
    {
        // Обновление отображения количества ходов 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Логика выбора кольца и основы
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Ring ring = hit.collider.GetComponent<Ring>();
                if (ring != null)
                {
                    // Перемещение кольца
                    int fromPeg = ring.CurrentPegIndex;
                    int toPeg = GetTargetPegIndex(); // Логика выбора целевой основы
                    Controller.MoveRing(fromPeg, toPeg);
                }
            }
        }
    }

    private int GetTargetPegIndex()
    {
        // Логика выбора целевой основы
        return 0; // Пример
    }
}