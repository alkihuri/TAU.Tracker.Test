using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TowerOfLondonController Controller;
    private List<RingAnchor> _ringAnchors = new List<RingAnchor>();
    private Ring _selectedRing; // Выбранное кольцо для перемещения
    private Vector3 _offset; // Смещение между позицией мыши и позицией кольца 
    public void Init(TowerOfLondonController controller)
    {
        if (controller == null)
        {
            Debug.LogError("Controller не установлен");
            return;
        }
        Controller = controller;

        // Подписка на изменения
        Controller.OnStateChanged += UpdateView;
        Controller.OnMovesChanged += UpdateMoves;

        var currentCongifuration = Controller.Domain.GetCurrentConfiguration();
        var targetConfiguration = Controller.Domain.GetTargetConfiguration();

        // Иннициализация основ и колец
        InitializeRingAnchors();
        InitializeRings(currentCongifuration);



        _ringAnchors = GetComponentsInChildren<RingAnchor>().ToList();
        for (int i = 0; i < _ringAnchors.Count; i++)
        {
            _ringAnchors[i].Initialize(i + 1);
        }
    }

    private void InitializeRings(RingsConfiguration currentCongifuration)
    {
        for(int i=0;i< _ringAnchors.Count;i++)
        {
            for(int j = 0; j < _ringAnchors[i].Rings.Count; j++) 
            {
                Ring ring = _ringAnchors[i].Rings[j];
                if (ring == null)
                {
                    Debug.LogError("Ring не найден");
                    return;
                }
                if (currentCongifuration.Configuration[i].Count <= j)
                {
                    ring.gameObject.SetActive(false);
                    continue;
                }
                ring.Initialize(currentCongifuration.Configuration[i][j], i + 1);
            }
        }
    }

    private void InitializeRingAnchors()
    {
        _ringAnchors = GetComponentsInChildren<RingAnchor>().ToList();
        for (int i = 0; i < _ringAnchors.Count; i++)
        {
            _ringAnchors[i].Initialize(i + 1);
        }
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
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        // Логика перемещения кольца мышкой
        if (Input.GetMouseButtonDown(0))
        {
            SelectRing();
        }

        if (Input.GetMouseButton(0) && _selectedRing != null)
        {
            MoveRing();
        }

        if (Input.GetMouseButtonUp(0))
        {
            DropRing();
        }
    }

    private void SelectRing()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Ring ring = hit.collider.GetComponent<Ring>();
            if (ring != null)
            {
                _selectedRing = ring;
                _selectedRing.Highlite(); // Подсветка выбранного кольца
                _offset = _selectedRing.transform.position - GetMouseWorldPosition(); // Вычисляем смещение
            }
        }
    }

    private void MoveRing()
    {
        if (_selectedRing == null) return;

        // Перемещаем кольцо вместе с курсором мыши
        Vector3 newPosition = GetMouseWorldPosition() + _offset;
        _selectedRing.transform.position = new Vector3(newPosition.x, _selectedRing.transform.position.y, newPosition.z);
    }

    private void DropRing()
    {
        if (_selectedRing == null) return;

        // Сбрасываем выбранное кольцо
        _selectedRing.ResetHighlight(); // Убираем подсветку
        _selectedRing.ResetPosition(); // Возвращаем кольцо на исходную позицию
        _selectedRing = null;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Получаем позицию мыши в мировых координатах
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(_selectedRing.transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}