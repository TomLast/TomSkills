using System.Collections.Generic;
using TomSkills;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "Effects/Buff")]
public class BuffEffect : Effect
{
    public List<StatType> EffectingTypes = new List<StatType>();

    public override void Use(Champion target, int amount)
    {
        foreach (var type in EffectingTypes)
        {
            target.Stats.GetStatValue(type).Value += amount;
        }
    }
}
