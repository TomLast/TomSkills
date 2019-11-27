using System.Collections.Generic;
using TomSkills;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public abstract void Use(Champion target, int amount);
}