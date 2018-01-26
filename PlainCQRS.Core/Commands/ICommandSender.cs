namespace PlainCQRS.Core.Commands
{
    /// <summary>
    ///     Defines a synchronous dispatcher for commands.
    /// </summary>
    public interface ICommandSender
    {
        /// <summary>
        ///    Synchronously sends command to a single handler.
        /// </summary>
        /// <typeparam name="TCommand">Command type.</typeparam>
        /// <param name="command">Command object.</param>
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}