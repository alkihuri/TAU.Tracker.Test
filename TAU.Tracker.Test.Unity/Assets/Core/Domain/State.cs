using UnityEngine;  

public abstract class State
{
    public abstract void Enter(StateMachine stateMachine);
    public abstract void Exit(StateMachine stateMachine);
    public abstract void Update(StateMachine stateMachine);
}

public class PlayingState : State
{
    private IGameLogic _gameLogic;

    public PlayingState(IGameLogic gameLogic)
    {
        _gameLogic = gameLogic;
    }

    public override void Enter(StateMachine stateMachine)
    {
        Debug.Log("Enter Playing State");
    }

    public override void Exit(StateMachine stateMachine)
    {
        Debug.Log("Exit Playing State");
    }

    public override void Update(StateMachine stateMachine)
    {
        
    }
}

public class WinState : State
{
    public override void Enter(StateMachine stateMachine)
    {
        Debug.Log("You Win!");
    }

    public override void Exit(StateMachine stateMachine)
    {
        Debug.Log("Exit Win State");
    }

    public override void Update(StateMachine stateMachine)
    {
        // Логика для WinState
    }
}

public class LoseState : State
{
    public override void Enter(StateMachine stateMachine)
    {
        Debug.Log("You Lose!");
    }

    public override void Exit(StateMachine stateMachine)
    {
        Debug.Log("Exit Lose State");
    }

    public override void Update(StateMachine stateMachine)
    {
        // Логика для LoseState
    }
}