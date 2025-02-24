using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class AnchorUIController : MonoBehaviour
{
    [SerializeField] private List<RingUIController> _ringAnchors = new List<RingUIController>();

    public void UpdateUI(List<int> list)
    { 
        for (int i = 0; i < list.Count; i++)
        { 
            if (_ringAnchors[i] != null)
                _ringAnchors[i].UpdateUI(list[i]);
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        _ringAnchors = GetComponentsInChildren<RingUIController>(true).ToList();
    }


}
