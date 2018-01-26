using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Core.Commands
{
    /// <summary>
    ///     Defines an asynchronous dispatcher for commands.
    /// </summary>
    public interface ICommandSenderAsync
    {
        /// <summary>
        ///     Asynchronously sends command to a single handler.
        /// </summary>
        /// <typeparam name="TCommand">Command type.</typeparam>
        /// <param name="command">Command object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task that represents an asynchronous operation.</returns>
        Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default(CancellationToken)) 
            where TCommand : ICommand;
    }
}