using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Core.Commands
{
    public interface ICommandHandlerAsync<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, CancellationToken cancellationToken = default(CancellationToken));
    }
}