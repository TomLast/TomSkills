using TomSkills;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "Effects/Damage")]
public class DamgeEffect : Effect
{
    public StatType Resistence;
    public StatType HealthType;

    public override void Use(Champion target, int amount)
    {
        int resistence = Resistence == null ? 0 : target.Stats.GetStatValue(Resistence);

        target.Stats.GetStatValue(HealthType).Value -= Mathf.Clamp(amount - resistence, 0, int.MaxValue);
    }
}