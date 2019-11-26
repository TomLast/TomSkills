using System.Collections.Generic;
using TomSkills;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public StatType EffectingStats;
    public int Value;
    public bool isValuePercentage;

    public virtual void Use<T>(Champion caster, FloatReference stat)
    {
        if (EffectingStats.GetType() != typeof(T)) return;
    }
}
