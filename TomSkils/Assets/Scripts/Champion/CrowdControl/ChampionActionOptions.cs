using System.Collections;
using System.Collections.Generic;
using TomSkills;
using UnityEngine;

[CreateAssetMenu(fileName ="ActionOptions", menuName = "CrowdControl/ActionOptions")]
public class ChampionActionOptions : ScriptableObject
{
    [HideInInspector]public Champion caster;
    [SerializeField] private List<ActionOption> actionOptions = new List<ActionOption>();
    private Dictionary<CrowdControl, IEnumerator> ccHandles = new Dictionary<CrowdControl, IEnumerator>();

    public bool CheckActionOption(ActionOption AO) => actionOptions.Contains(AO);

    public void ApplyCC(CrowdControl cc, float duration)
    {
        if (ccHandles.ContainsKey(cc))
        {
            caster.StopCoroutine(ccHandles[cc]);
            ccHandles.Remove(cc);
        }

        IEnumerator enumerator = Tasks.LerpHandle(duration, (float t) => { }, () => RemoveActionOptions(cc), () => ResetActionOptions(cc));
        ccHandles.Add(cc, enumerator);
        caster.StartCoroutine(enumerator);

    }

    private void RemoveActionOptions(CrowdControl cc)
    {
        foreach (var ao in cc.EffectingActionOptions)
        {
            if (actionOptions.Contains(ao))
                actionOptions.Remove(ao);
        }
    }

    private void ResetActionOptions(CrowdControl cc)
    {
        foreach (var ao in cc.EffectingActionOptions)
        {
            if (!actionOptions.Contains(ao))
                actionOptions.Add(ao);
        }
    }
}