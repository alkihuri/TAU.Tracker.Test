﻿using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private TowerOfLondonController _controller;
    [SerializeField] private TowerOfLondonDomainLogic _model;
    [SerializeField] private GameManager _view;

    private void Awake()
    {
        // Инициализация Model
        List<List<int>> targetConfigurationData = new List<List<int>>
        {
            new List<int> { 3, 2, 1 }, // Целевая конфигурация для первой основы
            new List<int> { 1, 2, 3 }, // Целевая конфигурация для второй основы
            new List<int> { 1, 3, 2 }  // Целевая конфигурация для третьей основы
        };

        RingsConfiguration ringsConfiguration = new RingsConfiguration(targetConfigurationData);
        _model = new TowerOfLondonDomainLogic(10, ringsConfiguration);

        // Инициализация Controller
        _controller = new TowerOfLondonController(_model);

        // Инициализация DIContainer
        DIContainer diContainer = new DIContainer();
        diContainer.Register<IGameLogic>(_model);

        // Инициализация StateMachine
        GameObject stateMachineObject = new GameObject("StateMachine");
        StateMachine stateMachine = stateMachineObject.AddComponent<StateMachine>();
        stateMachine.Init(diContainer);

        // Инициализация View
        GameObject gameManagerObject = new GameObject("GameManager");
        _view = gameManagerObject.AddComponent<GameManager>();
        _view.Init(_controller);
    }
}