using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private AnchorUIManager _currentAnchors;
    [SerializeField] private AnchorUIManager _targetAnchors;


    [ContextMenu("Update")]
    public void UpdateAnchors()
    {
        _currentAnchors.UpdateUI(GameObject.FindObjectOfType<GameManager>().Controller.Domain.CurrentConfiguration);
        _targetAnchors.UpdateUI(GameObject.FindObjectOfType<GameManager>().Controller.Domain.TargetConfiguration);
    }
}
