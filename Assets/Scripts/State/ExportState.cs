using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public class ExportState : AppState
{
    public ExportState(App app, AppStateMachine appStateMachine) : base(app, appStateMachine) { }

    override public async void EnterState()
    {
        string uniqueFileName = "export_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".json";
        string exportFilePath = Path.Combine(Application.persistentDataPath, uniqueFileName);
        await ExportDataAsync(exportFilePath);
    }

    private async Task ExportDataAsync(string filePath)
    {
        string defaultJson = JsonUtility.ToJson(app.ExportConfig);
        await Task.Run(() => File.WriteAllText(filePath, defaultJson));

        app.StateMachine.ChangeState(app.LoadingState);
    }
}