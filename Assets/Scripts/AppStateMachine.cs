using UnityEngine;

public class AppStateMachine
{
    public AppState CurrentAppState { get; set; }

    public void Initialize(AppState startingState)
    {
        CurrentAppState = startingState;
        CurrentAppState.EnterState();
    }

    public void ChangeState(AppState newState)
    {
        Debug.Log("Old State: " + CurrentAppState);
        CurrentAppState.ExitState();
        CurrentAppState = newState;
        CurrentAppState.EnterState();
        Debug.Log("New State: " + CurrentAppState);
    }
}