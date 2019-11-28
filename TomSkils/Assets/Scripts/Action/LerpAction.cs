using UnityEngine;

public class LerpAction : Action
{
    private readonly float duration;

    private float progress;

    public LerpAction(TimeTaskDel task, float duration, ActionStateDel stateCondition = null, Del init = null, Del callback = null) : base(stateCondition, task, init, callback)
    {
        this.duration = duration;
        base.stateCondition = stateCondition ?? Default;

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

    private ActionState Default() => progress >= 1f ? ActionState.SUCCESS : ActionState.RUNNING;

}
