using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTestScript : MonoBehaviour
{
    private Action action;
    private Action action2;
    public Action seq;
    public Action par;
    private Vector3 start;
    private float counter;
    IEnumerator actionHandle;
    private void Start()
    {
        //    start = transform.position;

        //    action = new TimeAction(CounterCheck, Count, () => { Debug.Log("Start 1"); counter = 0f; }, () => { Debug.Log(action.State); });
        //    //action2 = new TimeAction(CounterCheck, Count, () => { Debug.Log("Start 2"); counter = 0f; }, () => { Debug.Log(action.State); });
        //    action2 = new LerpAction(MoveCheck, Move, 5f, () => { Debug.Log("Start"); }, () => { Debug.Log(action.State); });
        //    seq = new ActionSequence(new List<Action>() { action, action2 }, this);
        //    par = new ActionParallel(new List<Action>() { action, action2 }, this);
        //action = new TickAction(CounterCheck, Move, 1f,5f, () => { Debug.Log("Start"); transform.position = Vector3.zero; }, () => { Debug.Log(action.State); });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(par.Execute());
        }
    }


    private void Move(float t) => transform.position = Vector3.Lerp(start, Vector3.right * 5, t);
    private void Count(float t) => counter = t;


    private ActionState MoveCheck()
    {
        return transform.position == Vector3.right * 5 ? ActionState.SUCCESS : ActionState.RUNNING;
    }

    private ActionState CounterCheck()
    {
        return counter >= 10f ? ActionState.SUCCESS : ActionState.RUNNING;
    }
}
