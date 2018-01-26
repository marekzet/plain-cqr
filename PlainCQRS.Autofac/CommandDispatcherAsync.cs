using Autofac;
using PlainCQRS.Core.Commands;
using PlainCQRS.Core.Common;
using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Autofac
{
    public class CommandDispatcherAsync : ICommandSenderAsync
    {
        private readonly IComponentContext componentContext;

        public CommandDispatcherAsync(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public async Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken =
            default(CancellationToken)) where TCommand : ICommand
        {
            ICommandHandlerAsync<TCommand> asyncHandler;

            if (componentContext.TryResolve(out asyncHandler))
            {
                await asyncHandler.HandleAsync(command, cancellationToken);
            }
            else
            {
                throw new HandlerNotFoundException($"Handler not registered for command: {command.GetType() }");
            }
        }
    }
}