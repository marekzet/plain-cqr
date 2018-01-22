using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Core.Commands
{
    public interface ICommandSenderAsync
    {
        Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default(CancellationToken)) 
            where TCommand : ICommand;
    }
}