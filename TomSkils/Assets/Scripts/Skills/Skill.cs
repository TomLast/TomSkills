using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TomSkills
{
    public abstract class Skill : ScriptableObject
    {
        public float Cooldown;
        public float CastTime;
        public abstract void Use(Champion caster);
    } 
}
