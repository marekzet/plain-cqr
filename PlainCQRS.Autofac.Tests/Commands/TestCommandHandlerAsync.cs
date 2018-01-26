using PlainCQRS.Core.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Autofac.Tests.Commands
{
    public class TestCommandHandlerAsync : ICommandHandlerAsync<TestCommand>
    {
        public Task HandleAsync(TestCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(0);
        }
    }
}