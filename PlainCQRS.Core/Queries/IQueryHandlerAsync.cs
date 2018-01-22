using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Core.Queries
{
    public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default(CancellationToken));
    }
}