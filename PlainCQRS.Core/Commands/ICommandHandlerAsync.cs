using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Core.Commands
{
    /// <summary>
    ///     Defines a handler that asynchronously handles a command.
    /// </summary>
    /// <typeparam name="TCommand">The type of command being handled.</typeparam>
    public interface ICommandHandlerAsync<in TCommand> where TCommand : ICommand
    {
        /// <summary>
        ///     Handles a command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task that represents an asynchronous operation.</returns>
        Task HandleAsync(TCommand command, CancellationToken cancellationToken = default(CancellationToken));
    }
}