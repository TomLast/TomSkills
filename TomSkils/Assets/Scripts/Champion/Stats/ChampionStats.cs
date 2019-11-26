using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stas", menuName = "ChampionStats/Stats")]
public class ChampionStats : ScriptableObject
{
    public List<StatValue> StatValues = new List<StatValue>();

    public FloatReference GetStatValue<T>()
    {
        foreach (StatValue stat in StatValues)
        {
            if(stat.StatType is T)
            {
                return stat.Value;
            }
        }
        return null;
    }
}
