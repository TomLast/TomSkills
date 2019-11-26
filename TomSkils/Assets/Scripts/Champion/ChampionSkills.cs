using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    public class ChampionSkills : MonoBehaviour
    {
        [SerializeField] private EventSystem eventSystem;
        [SerializeField] private List<SkillSlot> skillSlots = new List<SkillSlot>();

        private void Start()
        {
            if (eventSystem == null) return;

            for (int i = 0; i < skillSlots.Count; i++)
            {
                eventSystem.AddListener<Events.KeyDownEvent>(skillSlots[i].Use);
                skillSlots[i].caster = GetComponent<Champion>();
                skillSlots[i].ID = i;
                skillSlots[i].Init();
            }
        }
    }
}
