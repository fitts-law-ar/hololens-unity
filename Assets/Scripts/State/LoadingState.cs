using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public class LoadingState : AppState
{
    public LoadingState(App app, AppStateMachine appStateMachine) : base(app, appStateMachine) { }

    override public async void EnterState()
    {
        string configFilePath = Path.Combine(Application.persistentDataPath, "config.json");

        Config config = await LoadConfigAsync(configFilePath);

        app.SetConfig(config);

        app.StateMachine.ChangeState(app.MenuState);
    }

    private async Task<Config> LoadConfigAsync(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return await CreateDefaultConfigAsync(filePath);
        }

        return await LoadConfigFromFileAsync(filePath);
    }

    private async Task<Config> LoadConfigFromFileAsync(string filePath)
    {
        string json = await Task.Run(() => File.ReadAllText(filePath));
        return JsonUtility.FromJson<Config>(json);
    }

    private async Task<Config> CreateDefaultConfigAsync(string filePath)
    {
        Position[] defaultTestPositions = new Position[]
        {
            new(20, 20, 0.5f, 32, 32),
            new(50, 50, 0.5f, 32, 32),
            new(-20, -20, 0.5f, 32, 32)
        };

        Position[] defaultRunPositions = new Position[]
       {
            new(20, 20, 0.5f, 32, 32),
            new(50, 50, 0.5f, 32, 32),
            new(-20, -20, 0.5f, 32, 32)
       };

        Config defaultConfig = new()
        {
            testPositions = defaultTestPositions,
            runPositions = defaultRunPositions
        };

        string defaultJson = JsonUtility.ToJson(defaultConfig);
        await Task.Run(() => File.WriteAllText(filePath, defaultJson));

        return defaultConfig;
    }
}