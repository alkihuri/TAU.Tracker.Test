using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Start()
    {
        // Инициализация Model
        List<List<int>> targetConfiguration = new List<List<int>> { new List<int> { 3, 2, 1 }, new List<int>(), new List<int>() };
        TowerOfLondonDomainLogic model = new TowerOfLondonDomainLogic(10, targetConfiguration);

        // Инициализация Controller
        TowerOfLondonController controller = new TowerOfLondonController(model);

        // Инициализация View
        GameObject gameObject = new GameObject("TowerOfLondonView");
        var view = gameObject.AddComponent<TowerOfLondonView>(); ;
        view.Controller = controller;
    }
}