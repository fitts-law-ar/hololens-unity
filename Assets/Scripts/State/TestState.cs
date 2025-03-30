using UnityEngine;

public class TestState : AppState
{
    private RoundManager roundManager;
    private int currentPositionIndex = 0;
    private float lastClickTime = 0f;

    public TestState(App app, AppStateMachine appStateMachine) : base(app, appStateMachine)
    {
        roundManager = app.RoundManager;
    }

    override public void EnterState()
    {
        if (roundManager != null)
        {
            roundManager.OnAction += HandlePositionUpdate;
            roundManager.Show(app.Config.testPositions[currentPositionIndex]);
        }
        lastClickTime = Time.time;
        app.SetExportConfig(true, app.Config);
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
        if (currentPositionIndex >= app.Config.testPositions.Length)
        {
            app.StateMachine.ChangeState(app.ExportState);
            return;
        }

        roundManager.UpdatePosition(app.Config.testPositions[currentPositionIndex]);
    }

    private void LogActionTime(int positionIndex)
    {
        float timeSinceLastClick = Time.time - lastClickTime;
        app.SetExportConfigTimestamp(positionIndex, timeSinceLastClick);
        lastClickTime = Time.time;
    }
}