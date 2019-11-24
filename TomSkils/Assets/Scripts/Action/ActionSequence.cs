using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSequence : Action
{
    private List<Action> actions;
    private MonoBehaviour mb;
    private int currentActionIndex;
    private IEnumerator currentActionHandle;

    public ActionSequence(List<Action> actions, MonoBehaviour mb) : base(null, null)
    {
        this.actions = actions;
        this.mb = mb;

        stateCondition = () => State;
        task = TaskExecute;
        currentActionIndex = 0;
    }

    protected override void TaskExecute(float t)
    {
        // Start first action
        if(currentActionHandle == null)
        {
            currentActionHandle = actions[currentActionIndex].Execute();
            mb.StartCoroutine(currentActionHandle);
        }

        // All actions succeeded
        if (actions[currentActionIndex].State == ActionState.SUCCESS && currentActionIndex == actions.Count - 1)
            State = ActionState.SUCCESS;

        // Current action succeeded
        else if (actions[currentActionIndex].State == ActionState.SUCCESS)
        {
            currentActionIndex++;
            mb.StartCoroutine(currentActionHandle = actions[currentActionIndex].Execute());
        }

        // One of the actions failed
        else if (actions[currentActionIndex].State == ActionState.FAIL)
            State = ActionState.FAIL;
    }

    protected override void Init()
    {
        base.Init();
        currentActionIndex = 0;
        currentActionHandle = null;
    }
}
