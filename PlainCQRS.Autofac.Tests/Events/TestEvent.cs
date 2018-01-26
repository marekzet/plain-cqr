using PlainCQRS.Core.Events;
using System;

namespace PlainCQRS.Autofac.Tests.Events
{
    public class TestEvent : IEvent
    {
        public Guid Id => Guid.NewGuid();
    }
}