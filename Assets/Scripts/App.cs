using UnityEngine;
using System.Collections.Generic;

public class App : MonoBehaviour
{
    public AppStateMachine StateMachine { get; set; }
    public LoadingState LoadingState { get; set; }
    public MenuState MenuState { get; set; }
    public RoundState RoundState { get; set; }
    public TestState TestState { get; set; }
    public ExportState ExportState { get; set; }
    public MenuManager MenuManager;
    public RoundManager RoundManager;
    public Config Config { get; private set; }
    public ExportConfig ExportConfig { get; private set; }

    private void Awake()
    {
        StateMachine = new AppStateMachine();

        LoadingState = new LoadingState(this, StateMachine);
        MenuState = new MenuState(this, StateMachine);
        RoundState = new RoundState(this, StateMachine);
        TestState = new TestState(this, StateMachine);
        ExportState = new ExportState(this, StateMachine);
    }

    private void Start()
    {
        StateMachine.Initialize(LoadingState);
    }

    public void SetConfig(Config config)
    {
        Config = config;
    }

    public void SetExportConfig(bool isTestRun, Config data)
    {
        List<PositionWithTimestamp> positionsWithTimestamp = new List<PositionWithTimestamp>();

        if (isTestRun == true)
        {
            foreach (var position in data.testPositions)
            {
                PositionWithTimestamp posWithTimestamp = new(position.x, position.y, position.z, position.width, position.height, 0f);
                positionsWithTimestamp.Add(posWithTimestamp);
            }
        } else
        {
            foreach (var position in data.runPositions)
            {
                PositionWithTimestamp posWithTimestamp = new(position.x, position.y, position.z, position.width, position.height, 0f);
                positionsWithTimestamp.Add(posWithTimestamp);
            }
        }

        ExportConfig = new ExportConfig(isTestRun, positionsWithTimestamp.ToArray());
    }

    public void SetExportConfigTimestamp(int positionIndex, float newTimestamp)
    {
        ExportConfig.positions[positionIndex].timestamp = newTimestamp;
    }
}