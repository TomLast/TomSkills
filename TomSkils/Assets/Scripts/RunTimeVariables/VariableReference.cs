public class VariableReference<T>
{
    public bool UseConstant = true;
    public T ConstantValue;
    public Variable<T> Variable;

    public VariableReference()
    { }

    public VariableReference(T value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public T Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
        set
        {
            if (UseConstant) ConstantValue = value;
            else
                Variable.Value = value;
        }
    }
}