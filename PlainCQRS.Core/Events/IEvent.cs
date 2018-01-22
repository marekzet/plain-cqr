namespace PlainCQRS.Core.Events
{
    public interface IEvent
    {
        string Name { get; }
        string Type { get; }
    }
}