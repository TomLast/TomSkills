using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TomSkills
{
    public class SkillSlotUI : MonoBehaviour
    {
        [SerializeField] private EventSystem eventSystem;
        [SerializeField] private int SlotID;

        private Image img;
        private float skillCooldown;

        private void Start()
        {
            eventSystem.AddListener<Events.SkillSlotUsedEvent>(SkillUsed);
            img = GetComponent<Image>();
        }

        public void SkillUsed(Events.BaseEvent e)
        {
            Events.SkillSlotUsedEvent skillSlotUsedEvent = (Events.SkillSlotUsedEvent)e;
            if (skillSlotUsedEvent.SkillSlotID != SlotID) return;
            skillCooldown = skillSlotUsedEvent.Skill.Cooldown;
            if (skillCooldown == 0) return;
            StartCoroutine(Tasks.LerpHandle(skillCooldown, SetFillAmount));
            //StartCoroutine(Tasks.TickHandle(skillCooldown, 1f, SetFillAmount, ()=>img.fillAmount = 0f));
        }

        private void SetFillAmount(float t) => img.fillAmount = Mathf.Lerp(0, 1, t);
    } 
}
