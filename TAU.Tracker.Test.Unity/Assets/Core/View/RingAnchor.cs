using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingAnchor : MonoBehaviour
{
    public int Index; // Индекс основы  
    public List<Ring> Rings = new List<Ring>(); // Кольца, находящиеся на основе

    public Vector3 Position { get => transform.position + new Vector3(0, ((float)Rings.Count + 1) / 4, 0); }

    public void Initialize(int index)
    {
        Index = index;
        Rings = new List<Ring>(GetComponentsInChildren<Ring>());
        Rings.ForEach(ring =>
        {
            ring.Initialize(1, Index);
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ring ring))
        {
            if (ring.CurrentAnchor != null)
                ring.CurrentAnchor.Rings.Remove(ring);

            if(!Rings.Contains(ring)) 
                Rings.Add(ring);
            ring.SetAtAnchor(this);
            Debug.Log($"Ring {ring.Size} set at anchor {Index}");
        }
    }
}
