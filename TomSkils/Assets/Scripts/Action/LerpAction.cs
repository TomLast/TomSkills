public class LerpAction : Action
{
    private readonly float duration;

    private float progress;

    public LerpAction(ActionStateDel stateCondition, TimeTaskDel task, float duration, Del init = null, Del callback = null) : base(stateCondition, task, init, callback)
    {
        this.duration = duration;
    }

    protected override void TaskExecute(float t)
    {
        progress = t / duration >= 1f && Tasks.ExecuteHelper(task, 1f) ? 2f : (Tasks.ExecuteHelper(task, progress) ? (t / duration) : 0f);
    }

    protected override void Init()
    {
        base.Init();
        progress = 0f;
    }
}
