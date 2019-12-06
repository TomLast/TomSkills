using System.Collections;
using System.Collections.Generic;
using TomSkills;
using UnityEngine;

[CreateAssetMenu(fileName = "CC", menuName = "CrowdControl/CC")]
public class CrowdControl : ScriptableObject
{
    public List<ActionOption> EffectingActionOptions = new List<ActionOption>();

    public void Use(Champion target, float duration)
    {
        target.ActionOptions.ApplyCC(this, duration);
    }
}
