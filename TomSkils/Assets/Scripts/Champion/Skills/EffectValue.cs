[System.Serializable]
public struct EffectWrapper
{
    public EffectValue EffectValue;
    public ActionWrapper ActionWrapper;
}

[System.Serializable]
public struct EffectValue
{
    public Effect Effect;
    public IntReference Value;
}
