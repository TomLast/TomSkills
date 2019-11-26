using System.Collections;
using System.Collections.Generic;
using TomSkills;
using UnityEngine;

[CreateAssetMenu(fileName = "PermanentEffect", menuName = "Effects/Permanent")]
public class PermanentEffect : Effect
{
    public override void Use<T>(Champion caster, FloatReference stat)
    {
        base.Use<T>(caster, stat);
        stat.Value += isValuePercentage ? stat.Value * (Value / 100) : Value;
    }
}
