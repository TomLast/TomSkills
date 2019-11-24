using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    [CreateAssetMenu]
    public class TestSkill : Skill
    {
        public override void Use(Champion caster)
        {
            Debug.Log("Test Skill used");
        }
    } 
}
