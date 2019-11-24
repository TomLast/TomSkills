namespace TomSkills
{
    public interface IBaseEventListener
    {
        void OnEventRaised<T>(T data);
    }
}