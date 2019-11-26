using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionParallel : Action
{
    private List<Action> actions;
    private List<IEnumerator> actionHandles;
    private MonoBehaviour mb;


    public ActionParallel(List<Action> actions, MonoBehaviour mb) : base(null, null)
    {
        this.actions = actions;
        this.mb = mb;

        stateCondition = () => State;
        task = TaskExecute;
    }

    protected override void TaskExecute(float t)
    {
        if (actionHandles == null) InitHandles();

        foreach(Action action in actions)
        {
            if (action.State == ActionState.RUNNING)
                return;
        }
        State = ActionState.SUCCESS;
    }

    private void InitHandles()
    {
        actionHandles = new List<IEnumerator>();

        foreach(Action action in actions)
        {
            actionHandles.Add(action.Execute());
            mb.StartCoroutine(action.Execute());
        }
    }

    protected override void Init()
    {
        base.Init();
        actionHandles = null;
    }
}
