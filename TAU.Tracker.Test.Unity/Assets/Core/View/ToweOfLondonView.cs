using UnityEngine;

public class TowerOfLondonView : MonoBehaviour
{
    public TowerOfLondonController Controller;

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