using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    public abstract class PointAndClickSkill : Skill
    {
        public EventSystem eventSystem;
        public float SelectRadius;

        protected GameObject target;
        protected Champion caster;

        public override void Use(Champion caster)
        {
            if (this.caster == null) this.caster = caster;
            target = null;
            caster.IsUsingSelectSkill = true;
            caster.PaCRadius = SelectRadius;
            eventSystem?.AddListener<Events.GameObjectClickedEvent>(UseSkill);

        }

        protected abstract void PaCSkill();

        private void UseSkill(Events.BaseEvent e)
        {
            Events.GameObjectClickedEvent gameObjectEvent = (Events.GameObjectClickedEvent)e;

            if (gameObjectEvent.Value.GetComponent<Champion>() != null)
            {
                Debug.Log("Champion Target");
                target = gameObjectEvent.Value;
            }

            if (target != null && (target.transform.position - caster.transform.position).magnitude <= SelectRadius)
            {
                Debug.Log("Target set and in Range");

                PaCSkill();
            }
            caster.IsUsingSelectSkill = false;
            eventSystem?.RemoveListener<Events.GameObjectClickedEvent>(UseSkill);
        }
    }
}
