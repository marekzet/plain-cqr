namespace PlainCQRS.Core.Commands
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<TCommand> GetHandler<TCommand>() where TCommand : ICommand;
    }
}