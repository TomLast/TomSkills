using UnityEngine;

public class TickAction : Action
{
    private float tickIntervall;
    private float duration;
    private float tickTimer;
    private float progress;

    public TickAction(TimeTaskDel task, float tickIntervall, float duration, ActionStateDel condtion = null, Del init = null, Del callback = null) : base(condtion, task, init, callback)
    {
        this.tickIntervall = tickIntervall;
        this.duration = duration;

        base.stateCondition = condtion ?? Default;
    }

    protected override void Init()
    {
        base.Init();
        tickTimer = 0f;
        progress = 0f;
    }

    protected override void TaskExecute(float t)
    {
        tickTimer = (tickTimer + Time.deltaTime) >= tickIntervall && Tasks.ExecuteHelper(task, progress) ? tickIntervall - (tickTimer + Time.deltaTime) : tickTimer + Time.deltaTime;
        progress = t / duration;
    }

    private ActionState Default() => progress >= 1f ? ActionState.SUCCESS : ActionState.RUNNING;
}
