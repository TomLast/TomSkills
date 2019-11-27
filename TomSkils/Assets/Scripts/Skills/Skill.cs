using UnityEngine;

namespace TomSkills
{
    public abstract class Skill : ScriptableObject
    {
        public Sprite Icon;
        public float Cooldown;
        public float CastTime;
        public abstract void Use(Champion caster);
    } 
}
