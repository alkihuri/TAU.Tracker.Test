using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RingUIController : MonoBehaviour
{
    RectTransform rectTransform;
    TextMeshProUGUI textMeshProUGUI;
    private void Awake()
    {
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>(true);
        rectTransform = GetComponent<RectTransform>();
        textMeshProUGUI.text = "_";
    }
    public void UpdateUI(int position)
    {
        textMeshProUGUI.text = position == 0 ? "_" : position.ToString();
    }


}
