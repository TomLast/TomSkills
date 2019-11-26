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

        private void Awake()
        {
            img = GetComponent<Image>();
            eventSystem.AddListener<Events.SkillSlotUsedEvent>(SkillUsed);
            eventSystem.AddListener<Events.SkillSlotUpdate>(UpdateUI);
        }

        public void UpdateUI(Events.BaseEvent e)
        {
            Events.SkillSlotUpdate update = (Events.SkillSlotUpdate)e;
            if(update.SkillSlotID == SlotID)
            {
                img.sprite = update.Skill.Icon;
            }
        }

        public void SkillUsed(Events.BaseEvent e)
        {
            Events.SkillSlotUsedEvent skillSlotUsedEvent = (Events.SkillSlotUsedEvent)e;
            if (skillSlotUsedEvent.SkillSlotID != SlotID) return;

            skillCooldown = skillSlotUsedEvent.Skill.Cooldown;
            if (skillCooldown == 0) return;

            StartCoroutine(Tasks.LerpHandle(skillCooldown, SetFillAmount));
        }

        private void SetFillAmount(float t) => img.fillAmount = Mathf.Lerp(0, 1, t);
    } 
}
