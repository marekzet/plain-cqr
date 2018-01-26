using Autofac;
using PlainCQRS.Core.Commands;
using PlainCQRS.Core.Common;

namespace PlainCQRS.Autofac
{
    /// <summary>
    ///     Default implementation of synchronous dispatcher for commands.
    /// </summary>
    public class CommandDispatcher : ICommandSender
    {
        private readonly IComponentContext componentContext;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CommandDispatcher"/> class.
        /// </summary>
        /// <param name="componentContext">The context in which a service can be accessed or a component's dependencies resolved.</param>
        public CommandDispatcher(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            ICommandHandler<TCommand> handler;
            if (componentContext.TryResolve(out handler))
            {
                handler.Handle(command);
            }
            else
            {
                throw new HandlerNotFoundException($"Handler not registered for command: {command.GetType() }");
            }
        }
    }
}