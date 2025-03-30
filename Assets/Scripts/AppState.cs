public class AppState
{
    protected App app;
    protected AppStateMachine appStateMachine;

    public AppState(App app, AppStateMachine appStateMachine)
    {
        this.app = app;
        this.appStateMachine = appStateMachine;
    }

    public virtual void EnterState() { }

    public virtual void ExitState() { }
}