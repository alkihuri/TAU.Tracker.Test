using UnityEngine;

public class Ring : MonoBehaviour
{
    public int Size;  // Размер кольца (1 - маленькое, 2 - среднее, 3 - большое)
    public int CurrentPegIndex; // Индекс основы, на которой находится кольцо
    public Transform visual; // Визуальное представление кольца 

    public void Initialize(int size, int pegIndex)
    {
        if(visual==null)
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

    private void UpdateVisual()
    {
        // Логика обновления визуального представления кольца
        visual.localScale = new Vector3(Size, 1, Size); // Пример: размер кольца зависит от его "размера"
        Renderer renderer = visual.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.Lerp(Color.red, Color.green, Size / 3f); // Пример: цвет кольца зависит от его "размера"
        }
    }
}