using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    [CreateAssetMenu]
    public class TestSkill : Skill
    {
        public List<EffectValue> Effects;

        public override void Use(Champion caster)
        {
            Debug.Log("Test Skill used");
            foreach (var effect in Effects)
            {
                effect.Effect.Use(caster,effect.Value);
            }
        }
    } 
}
