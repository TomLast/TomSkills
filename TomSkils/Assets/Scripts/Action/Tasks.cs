using System.Collections;
using UnityEngine;

public static class Tasks
{
    public static IEnumerator LerpHandle(float time, TimeTaskDel task, Del init = null, Del callback = null)
    {
        IEnumerator coroutine = LerpExecute(time, task, init, callback);
        yield return coroutine;
    }

    public static IEnumerator TickHandle(float time, float tickIntervall, TimeTaskDel tickDel, Del init = null, Del callback = null)
    {
        IEnumerator coroutine = TickExecute(time, tickIntervall, tickDel, init, callback);
        yield return coroutine;
    }

    private static IEnumerator LerpExecute(float time, TimeTaskDel task, Del init = null, Del callback = null)
    {
        float progress = 0f;
        init?.Invoke();

        while (progress <= 1f)
        {
            progress += (progress + Time.deltaTime) >= 1 && ExecuteHelper(task, 1f) ? 2f : (ExecuteHelper(task, progress) ? (Time.deltaTime / time) : 0f);
            yield return null;
        }
        callback?.Invoke();
    }

    private static IEnumerator TickExecute(float time, float tickIntervall, TimeTaskDel tickDel, Del init = null, Del callback = null)
    {
        float progress = 0f;
        float tickTimer = 0f;

        init?.Invoke();

        while (progress < 1f)
        {
            tickTimer = (tickTimer + Time.deltaTime) >= tickIntervall && ExecuteHelper(tickDel, progress) ? tickIntervall - (tickTimer + Time.deltaTime) : tickTimer + Time.deltaTime;
            progress += Time.deltaTime / time;
            Debug.Log($"ticktimer: {tickTimer}");
            yield return null;
        }
        tickDel(1f);
        callback?.Invoke();
    }

    public static bool ExecuteHelper(TimeTaskDel task, float t)
    {
        task(t);
        return true;
    }
}
public delegate void TimeTaskDel(float t);
public delegate void Del();