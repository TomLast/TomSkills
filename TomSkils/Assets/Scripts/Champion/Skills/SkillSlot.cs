using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    [System.Serializable]
    public class SkillSlot
    {
        [SerializeField] private Skill skill;
        [SerializeField] private KeyCode key;
        [SerializeField] private EventSystem eventSystem;

        public Champion caster { get; set; }
        public int ID { get; set; }

        private Events.SkillSlotUsedEvent usedEvent;

        public void Init()
        {
            usedEvent = new Events.SkillSlotUsedEvent();
            usedEvent.SkillSlotID = ID;
            Events.SkillSlotUpdate update = new Events.SkillSlotUpdate();
            update.Skill = skill;
            update.SkillSlotID = ID;
            eventSystem.RaiseEvent<Events.SkillSlotUpdate>(update);
        }

        public void Use(Events.BaseEvent e)
        {
            Events.KeyDownEvent keyEvent = (Events.KeyDownEvent)e;

            if (keyEvent.Value == key && !caster.IsUsingSelectSkill)
            {
                skill.Use(caster);
                usedEvent.Skill = skill;
                eventSystem?.RaiseEvent<Events.SkillSlotUsedEvent>(usedEvent);
            }
        }
    } 
}
