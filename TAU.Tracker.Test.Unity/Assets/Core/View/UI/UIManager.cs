using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private AnchorUIManager _currentAnchors;
    [SerializeField] private AnchorUIManager _targetAnchors;
    [SerializeField] private TextMeshProUGUI _currentStep;


    [ContextMenu("Update")]
    public void UpdateAnchors()
    {


        try
        {
            _currentAnchors.Cler();
            _currentAnchors.UpdateUI(GameObject.FindObjectOfType<GameManager>().Controller.Domain.CurrentConfiguration);
        }
        catch
        {
            Debug.LogError("Current configuration is null");
        }

        try
        {
            _targetAnchors.Cler();
            _targetAnchors.UpdateUI(GameObject.FindObjectOfType<GameManager>().Controller.Domain.TargetConfiguration);
        }
        catch
        {
            Debug.LogError("Target configuration is null");
        }

        try
        {
            _currentStep.text =
            $"{GameObject.FindObjectOfType<GameManager>().Controller.Domain.CurrentMoves.ToString()}/{GameObject.FindObjectOfType<GameManager>().Controller.Domain.MaxMoves.ToString()}";
        }
        catch
        {
            Debug.LogError("Current moves is null");
        }
    }
}
