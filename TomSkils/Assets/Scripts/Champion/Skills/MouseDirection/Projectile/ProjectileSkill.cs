using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    [CreateAssetMenu]
    public class ProjectileSkill : MouseDirectionSkill
    {
        public GameObject ProjectilePrefab;
        public List<EffectWrapper> Effects;
        public EventSystem eventSystem;

        private GameObject projectile;

        public override void Use(Champion caster)
        {
            eventSystem.AddListener<Events.OnTriggerEnterEvent>(OnProjectileHit);
            dirDel = SpawnProjectile;
            base.Use(caster);
        }

        private void SpawnProjectile(Vector3 dir)
        {
            projectile = Instantiate(ProjectilePrefab);
            projectile.transform.position = caster.transform.position;
            Projectile p = projectile.GetComponent<Projectile>();
            p.Direction = new Vector3(dir.x, 0, dir.z);
            p.startPos = caster.transform.position;
        }

        private void OnProjectileHit(Events.BaseEvent e)
        {
            Events.OnTriggerEnterEvent enterEvent = (Events.OnTriggerEnterEvent)e;
            Champion c = enterEvent.Other.GetComponent<Champion>();

            if (c != caster)
            {
                Destroy(projectile);
                foreach (var effect in Effects)
                {
                    caster.StartCoroutine(effect.ActionWrapper.Execute(effect.EffectValue, c));
                }
            }
        }
    }
}
