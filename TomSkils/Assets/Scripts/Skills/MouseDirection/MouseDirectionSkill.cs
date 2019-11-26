using UnityEngine;

namespace TomSkills
{
    public abstract class MouseDirectionSkill : Skill
    {
        public RaycastHitVariable raycastHit;

        protected Champion caster;
        protected DirectionDel dirDel;

        public override void Use(Champion caster)
        {
            if (this.caster == null) this.caster = caster;
            dirDel((raycastHit.Value.point - caster.transform.position).normalized);
        }
    } 
}
public delegate void DirectionDel(Vector3 dir);
