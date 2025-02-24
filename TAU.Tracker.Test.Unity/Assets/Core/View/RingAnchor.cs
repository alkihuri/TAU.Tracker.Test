using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingAnchor : MonoBehaviour
{
    public int Index; // Индекс основы  
    public List<Ring> Rings = new List<Ring>(); // Кольца, находящиеся на основе
    public Action<int, int, int> OnAnchorChanged; // Уведомление об изменении количества колец на основе  
    public Vector3 Position { get => transform.position + new Vector3(0, ((float)Rings.Count + 1) / 4, 0); }

    public void Initialize(int size, int index)
    {
        Index = index;
        Rings = new List<Ring>(GetComponentsInChildren<Ring>());
        Rings.ForEach(ring =>
        {
            ring.Initialize(size, Index);
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ring ring))
        {
            var currentPegIndex = ring.CurrentPegIndex;


               
            
            
            var toPegIndex = Index;
            if (ring.CurrentAnchor != null)
                ring.CurrentAnchor.Rings.Remove(ring);

            if (!Rings.Contains(ring))
                Rings.Add(ring);
            ring.SetAtAnchor(this);
            OnAnchorChanged?.Invoke(ring.CurrentAnchor.Index, Index, ring.CurrentPegIndex);
            Debug.Log($"Ring {ring.Size} set at anchor {Index}");

            GameObject.FindObjectOfType<GameManager>().Controller.MoveRing(currentPegIndex, Index, ring.Size);

        }
    }
}
