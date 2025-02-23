using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Start()
    {
        // Инициализация DIContainer    
        DIContainer diContainer = new DIContainer();
        diContainer.GameLogic = new TowerOfLondonDomainLogic(10, new List<List<int>> { new List<int> { 3, 2, 1 }, new List<int>(), new List<int>() });

        // Инициализация StateMachine   
        GameObject gameObject1 = new GameObject("StateMachine");
        StateMachine stateMachine = gameObject1.AddComponent<StateMachine>();
        stateMachine.Init(diContainer);

        // Инициализация Model
        List<List<int>> targetConfiguration = new List<List<int>> { new List<int> { 3, 2, 1 }, new List<int>(), new List<int>() };
        TowerOfLondonDomainLogic model = new TowerOfLondonDomainLogic(10, targetConfiguration);
        // Инициализация Controller
        TowerOfLondonController controller = new TowerOfLondonController(model);
        // Инициализация View
        GameObject gameObject = new GameObject("GameManager");
        var view = gameObject.AddComponent<GameManager>(); ;
        view.Controller = controller;
    }
}