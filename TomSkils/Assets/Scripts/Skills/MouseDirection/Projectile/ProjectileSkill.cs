using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    [CreateAssetMenu]
    public class ProjectileSkill : MouseDirectionSkill
    {
        public GameObject ProjectilePrefab;

        public override void Use(Champion caster)
        {
            if (dirDel == null) dirDel = SpawnProjectile;
            base.Use(caster);
        }

        private void SpawnProjectile(Vector3 dir)
        {
            GameObject go = Instantiate(ProjectilePrefab);
            go.transform.position = caster.transform.position;
            Projectile p = go.GetComponent<Projectile>();
            p.Direction = new Vector3(dir.x, 0, dir.z);
            p.startPos = caster.transform.position;
        }
    }
}
