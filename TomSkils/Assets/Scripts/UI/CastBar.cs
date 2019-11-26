using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TomSkills
{
    public class CastBar : MonoBehaviour
    {
        [SerializeField] private GameObject castBar;
        [SerializeField] private EventSystem eventSystem;
        [SerializeField] private Image bar;

        private IEnumerator castHandle;

        private void Start()
        {
            eventSystem.AddListener<Events.SkillSlotUsedEvent>(InitCastBar);
        }

        private void InitCastBar(Events.BaseEvent e)
        {
            Events.SkillSlotUsedEvent skillSlotUsed = (Events.SkillSlotUsedEvent)e;

            if (skillSlotUsed.Skill.CastTime == 0) return;

            castBar.SetActive(true);
            castHandle = Tasks.LerpHandle(skillSlotUsed.Skill.CastTime, (float t) => bar.fillAmount = Mathf.Lerp(0, 1, t), () => bar.fillAmount = 0, ()=>castBar.SetActive(false));
            StartCoroutine(castHandle);
        }
    } 
}
