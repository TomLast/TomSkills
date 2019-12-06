using TomSkills;
using UnityEngine;

[CreateAssetMenu(fileName = "CCEffect", menuName = "Effects/CC")]
public class CCEffect : Effect
{
    public CrowdControl CC;

    public override void Use(Champion target, int amount)
    {
        target.ActionOptions.ApplyCC(CC, amount);
    }
}
