using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAction : Action
{
    public TimeAction(ActionStateDel stateCondition, TimeTaskDel task, Del init = null, Del callback = null) : base(stateCondition, task, init, callback) { }

    protected override void TaskExecute(float t) => task(t);
}
