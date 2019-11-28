using System.Collections;
using System.Collections.Generic;
using TomSkills;
using UnityEngine;

[System.Serializable]
public class ActionWrapper
{
    public float Duration;
    public float TickIntervall;
    public bool ResetAtEnd;

    private Action action;
    private EffectValue effect;
    private Champion target;
    private int appliedAmount;

    public IEnumerator Execute(EffectValue effect, Champion target)
    {
        this.effect = effect;
        this.target = target;

        if (Duration == 0)
        {
            action = new TimeAction(() => ActionState.SUCCESS, Effect, () => { if (ResetAtEnd) appliedAmount = 0; }, () => { if (ResetAtEnd) effect.Effect.Use(target, -appliedAmount) ; });
        }
        else if(TickIntervall == 0)
        {
            action = new LerpAction((float t)=> { }, Duration, null, () => { if (ResetAtEnd) appliedAmount = 0; Effect(0f); }, () => { Debug.Log("Reset"); if (ResetAtEnd) effect.Effect.Use(target, -appliedAmount); });

        }
        else
        {
            action = new TickAction(Effect, TickIntervall, Duration, null, () => { if (ResetAtEnd) appliedAmount = 0; }, () => { if (ResetAtEnd) effect.Effect.Use(target, -appliedAmount); });
        }

        yield return target.StartCoroutine(action.Execute());
    }

    private void Effect(float t)
    {
        if (ResetAtEnd) appliedAmount += effect.Value;
        effect.Effect.Use(target, effect.Value);
    }
}
