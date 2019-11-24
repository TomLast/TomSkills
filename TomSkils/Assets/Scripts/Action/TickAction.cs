using UnityEngine;

public class TickAction : Action
{
    private float tickIntervall;
    private float duration;
    private float tickTimer;
    private float progress;

    public TickAction(ActionStateDel condtion, TimeTaskDel task, float tickIntervall, float duration, Del init = null, Del callback = null) : base(condtion, task, init, callback)
    {
        this.tickIntervall = tickIntervall;
        this.duration = duration;
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
}
