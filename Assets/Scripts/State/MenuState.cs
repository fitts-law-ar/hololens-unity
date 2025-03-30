using UnityEngine;

public class MenuState : AppState
{
    private MenuManager menuManager;
    public MenuState(App app, AppStateMachine appStateMachine) : base(app, appStateMachine)
    {
        menuManager = app.MenuManager;
    }

    override public void EnterState()
    {
        if (menuManager != null)
        {
            menuManager.OnAction += HandleMenuClick;
            menuManager.Show();
        }
    }

    override public void ExitState()
    {
        if (menuManager != null)
        {
            menuManager.OnAction -= HandleMenuClick;
            menuManager.Hide();
        }
    }

    private void HandleMenuClick(string buttonType)
    {
        if (buttonType == "round")
        {
            app.StateMachine.ChangeState(app.RoundState);
        }
        else if (buttonType == "test")
        {            
            app.StateMachine.ChangeState(app.TestState);
        }
    }
}