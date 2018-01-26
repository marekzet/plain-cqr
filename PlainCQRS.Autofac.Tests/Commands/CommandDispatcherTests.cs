using PlainCQRS.Core.Commands;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PlainCQRS.Autofac.Tests.Commands
{
    public class CommandDispatcherTests : AutofacTest<CommandsModule>, IDisposable
    {
        [Fact]
        public void should_execute_command_using_registered_handler()
        {
            var command = new TestCommand();

            var commandBus = Resolve<ICommandSender>();

            commandBus.Send(command);
        }

        [Fact]
        public async Task should_execute_command_asynchronously_using_registered_handler()
        {
            var command = new TestCommand();

            var commandBusAsync = Resolve<ICommandSenderAsync>();

            await commandBusAsync.SendAsync(command);
        }

        public void Dispose()
        {
            CleanUpContainer();
        }
    }
}