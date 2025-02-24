using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnchorUIManager : MonoBehaviour
{
    [SerializeField] private List<AnchorUIController> _anchorsUI = new List<AnchorUIController>();
    // Start is called before the first frame update
    void Awake()
    {
        _anchorsUI = GetComponentsInChildren<AnchorUIController>(true).ToList();
    }


    [ContextMenu("test")]
    public void Test()
    {
        List<List<int>> test = new List<List<int>>()
        {
            new List<int>(){1,2,3},
            new List<int>(){4,5,6},
            new List<int>(){7,8,9}
        };
        UpdateUI(new RingsConfiguration(test));
    }

    public void UpdateUI(RingsConfiguration config)
    {
        if (config == null)
        {
            Debug.LogError("RingsConfiguration is null");
            return;
        }
        for (int i = 0; i < _anchorsUI.Count; i++)
        {
            if (i < config.Configuration.Count)
                _anchorsUI[i].UpdateUI(config.Configuration[i]);
        }
    }


}
