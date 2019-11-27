using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stas", menuName = "ChampionStats/Stats")]
public class ChampionStats : ScriptableObject
{
    public List<StatValue> StatValues = new List<StatValue>();

    public IntReference GetStatValue(StatType statType)
    {
        foreach (StatValue stat in StatValues)
        {
            if(stat.StatType == statType)
            {
                return stat.Value;
            }
        }
        return null;
    }
}
