using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingAnchor : MonoBehaviour
{
    public int Index; // Индекс основы  
    public List<Ring> Rings = new List<Ring>(); // Кольца, находящиеся на основе

    public void Initialize(int index)
    {
        Index = index;  
        Rings = new List<Ring>(GetComponentsInChildren<Ring>());
        Rings.ForEach(ring =>
        {
            ring.Initialize(1, Index);
        });
    }
}
