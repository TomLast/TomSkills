using System.Collections;
using System.Collections.Generic;
using TomSkills;
using UnityEngine;

//[CreateAssetMenu(fileName = "TimeEffect", menuName = "Effects/Time")]
//public class TimeEffect : Effect
//{
//    public float Duration;

//    private IEnumerator effectHandle;

//    public override void Use<T>(Champion caster, IntReference stat)
//    {
//        base.Use<T>(caster, stat);
//        int bonus = isValuePercentage ? (int)(stat * (Value * 0.01f)) : Value;
//        effectHandle = Tasks.LerpHandle(Duration, (float t) => { }, () => stat.Value += bonus, () => stat.Value -=bonus);
//        caster.StartCoroutine(effectHandle);
//    }
//}
