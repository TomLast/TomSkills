﻿[System.Serializable]
public class FloatReference// : VariableReference<float>
{
    public bool UseConstant = true;
    public float ConstantValue;
    public FloatVariable Variable;

    public FloatReference()
    { }

    public FloatReference(float value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public float Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
        set
        {
            if (UseConstant) ConstantValue = value;
            else
                Variable.Value = value;
        }
    }

    public static implicit operator float(FloatReference reference)
    {
        return reference.Value;
    }
}

