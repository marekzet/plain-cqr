namespace PlainCQRS.Core.Commands
{
    /// <summary>
    ///     Defines a handler that synchronously handles a command.
    /// </summary>
    /// <typeparam name="TCommand">The type of command being handled.</typeparam>
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        /// <summary>
        ///     Handles a command.
        /// </summary>
        /// <param name="command">The command.</param>
        void Handle(TCommand command);
    }
}