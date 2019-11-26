using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    public class Events
    {
        public class BaseEvent { }

        public class KeyEvent : BaseEvent
        {
            public KeyCode Value { get; set; }
        }
        public class KeyDownEvent : KeyEvent
        {
        }

        public class GameObjectClickedEvent : BaseEvent
        {
            public GameObject Value;
            public Vector3 pos;
            public KeyCode mouseKey;
        }

        public class SkillSlotUsedEvent : BaseEvent
        {
            public Skill Skill;
            public int SkillSlotID;
        }

        public class SkillSlotUpdate : BaseEvent
        {
            public Skill Skill;
            public int SkillSlotID;
        }
    }
}
