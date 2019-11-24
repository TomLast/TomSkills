using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    [CreateAssetMenu]
    public class SuperSkill : Skill
    {
        public override void Use(Champion caster)
        {
            GameObject go =  GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.position = caster.transform.position + Vector3.forward;
        }
    } 
}
