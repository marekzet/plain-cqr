using System;

namespace PlainCQRS.Core.Events
{
    public interface IEvent
    {
        Guid Id { get; }
    }
}