using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Core.Queries
{
    public interface IQueryDispatcherAsync
    {
        Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default(CancellationToken));
    }
}