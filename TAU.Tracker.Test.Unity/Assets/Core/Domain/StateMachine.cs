using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public DIContainer DIContainer { get; private set; }
    public State CurrentState { get; private set; }
    public State PreviousState { get; private set; }

    public StateType CurrentStateType;

    private WinState _winState;
    private LoseState _loseState;
    private PlayingState _playingState;

    public StateMachine(DIContainer diContainer)
    {
        DIContainer = diContainer;
        _winState = new WinState();
        _loseState = new LoseState();
        _playingState = new PlayingState(DIContainer.GameLogic);
    }

    private void ChangeState(State newState)
    { 
        if (CurrentState != null)
        {
            CurrentState.Exit(this);
            PreviousState = CurrentState;
            UnityEngine.Debug.Log($"Состояние изменилось с {PreviousState} на {newState}");
        }
        CurrentState = newState;
        CurrentState.Enter(this);
        UnityEngine.Debug.Log($"Состояние изменилось на {CurrentState}");
    }

    public void SetWinState() => ChangeState(_winState);
    public void SetLoseState() => ChangeState(_loseState);
    public void SetPlayingState() => ChangeState(_playingState);

}

public enum StateType
{
    Win,
    Lose,
    Playing
}   