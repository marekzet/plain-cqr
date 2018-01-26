using PlainCQRS.Core.Commands;
using System;

namespace PlainCQRS.Autofac.Tests.Commands
{
    public class TestCommandHandler : ICommandHandler<TestCommand>
    {
        public void Handle(TestCommand command)
        {
        }
    }
}