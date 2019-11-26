using UnityEngine;

namespace TomSkills
{
    public abstract class PointAndClickSkill : Skill
    {
        public EventSystem eventSystem;
        public float SelectRadius;

        protected Champion caster;

        public override void Use(Champion caster)
        {
            if (this.caster == null) this.caster = caster;
            caster.IsUsingSelectSkill = true;
            caster.PaCRadius = SelectRadius;
            eventSystem?.AddListener<Events.GameObjectClickedEvent>(UseSkill);

        }

        protected abstract void PaCSkill(GameObject target);

        private void UseSkill(Events.BaseEvent e)
        {
            Events.GameObjectClickedEvent gameObjectEvent = (Events.GameObjectClickedEvent)e;

            if ((gameObjectEvent.Value.transform.position - caster.transform.position).magnitude <= SelectRadius)
            {
                Debug.Log("Target set and in Range");

                PaCSkill(gameObjectEvent.Value);
            }
            caster.IsUsingSelectSkill = false;
            eventSystem?.RemoveListener<Events.GameObjectClickedEvent>(UseSkill);
        }
    }
}
