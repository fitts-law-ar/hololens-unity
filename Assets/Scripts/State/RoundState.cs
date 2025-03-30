using UnityEngine;

public class RoundState : AppState
{
    private RoundManager roundManager;
    private int currentPositionIndex = 0;
    private float lastClickTime = 0f;

    public RoundState(App app, AppStateMachine appStateMachine) : base(app, appStateMachine)
    {
        roundManager = app.RoundManager;
    }

    override public void EnterState()
    {
        if (roundManager != null)
        {
            roundManager.OnAction += HandlePositionUpdate;
            roundManager.Show(app.Config.runPositions[currentPositionIndex]);
        }
        lastClickTime = Time.time;
        app.SetExportConfig(false, app.Config);
    }

    override public void ExitState()
    {
        if (roundManager != null)
        {
            roundManager.OnAction -= HandlePositionUpdate;
            roundManager.Hide();
        }
        currentPositionIndex = 0;
    }

    private void HandlePositionUpdate()
    {
        LogActionTime(currentPositionIndex);

        currentPositionIndex++;
        if (currentPositionIndex >= app.Config.runPositions.Length)
        {
            app.StateMachine.ChangeState(app.ExportState);
            return;
        }

        roundManager.UpdatePosition(app.Config.runPositions[currentPositionIndex]);
    }

    private void LogActionTime(int positionIndex)
    {
        float timeSinceLastClick = Time.time - lastClickTime;
        app.SetExportConfigTimestamp(positionIndex, timeSinceLastClick);
        lastClickTime = Time.time;
    }
}