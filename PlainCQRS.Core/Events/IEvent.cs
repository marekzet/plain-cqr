using System;

namespace PlainCQRS.Core.Events
{
    /// <summary>
    ///     Marker interface to represent event.
    /// </summary>
    public interface IEvent
    {
        Guid Id { get; }
    }
}