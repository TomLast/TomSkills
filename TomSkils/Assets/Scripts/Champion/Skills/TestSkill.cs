using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    [CreateAssetMenu]
    public class TestSkill : Skill
    {
        public List<EffectWrapper> Effects;

        public override void Use(Champion caster)
        {
            Debug.Log("Test Skill used");
            foreach (var effect in Effects)
            {
                caster.StartCoroutine(effect.ActionWrapper.Execute(effect.EffectValue, caster));
            }
        }
    } 
}
