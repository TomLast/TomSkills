using System.Collections;
using UnityEngine;

public abstract class Action
{
    public ActionState State { get; protected set; } = ActionState.RUNNING;

    protected ActionStateDel stateCondition;
    protected TimeTaskDel taskExecute;
    protected TimeTaskDel task;
    protected Del init;
    protected Del callback;

    public Action(ActionStateDel stateCondition,TimeTaskDel task, Del init = null, Del callback = null)
    {
        this.stateCondition = stateCondition;
        taskExecute = TaskExecute;
        this.task = task;
        this.init = init + Init;
        this.callback = callback;
    }

    public IEnumerator Execute()
    {
        IEnumerator actionHandle = ExecuteCoroutine();
        yield return actionHandle;
    }

    private IEnumerator ExecuteCoroutine()
    {
        float time = 0f;
        init?.Invoke();
        Init();

        while (State == ActionState.RUNNING)
        {
            taskExecute(time += Time.deltaTime);
            State = stateCondition();
            yield return null;
        }

        callback?.Invoke();
    }

    protected abstract void TaskExecute(float t);
    protected virtual void Init() => State = ActionState.RUNNING;
}
public enum ActionState
{
    RUNNING,
    SUCCESS,
    FAIL
}
public delegate ActionState ActionStateDel();