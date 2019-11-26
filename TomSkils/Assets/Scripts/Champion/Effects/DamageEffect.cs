using System.Collections;
using System.Collections.Generic;
using TomSkills;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "Effects/Damage")]
public class DamageEffect : PermanentEffect
{
    public DamageType Type;

    public override void Use<T>(Champion caster, FloatReference stat)
    {
        if (typeof(T) != typeof(Healthpoints)) return;
        float resistence = Type == DamageType.NORMAL ? caster.Stats.GetStatValue<Armor>() : (Type == DamageType.ABSOLUTE ? 0 : caster.Stats.GetStatValue<Magicresist>().Value);
        stat.Value -= Value - resistence;
        Debug.Log(Value - resistence);
    }
}
public enum DamageType
{
    NORMAL,
    MAGIC,
    ABSOLUTE
}