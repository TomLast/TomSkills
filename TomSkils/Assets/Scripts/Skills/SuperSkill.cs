using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    [CreateAssetMenu]
    public class SuperSkill : MouseDirectionSkill
    {
        public override void Use(Champion caster)
        {
            if(dirDel == null)dirDel = SpawnSphere;
            base.Use(caster);            
        }

        private void SpawnSphere(Vector3 dir)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.position = caster.transform.position + new Vector3(dir.x, 0.5f, dir.z);
        }
    } 
}
