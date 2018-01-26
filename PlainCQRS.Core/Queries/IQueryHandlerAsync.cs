using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Core.Queries
{
    /// <summary>
    ///     Defines a handler that asynchronously handles a query.
    /// </summary>
    /// <typeparam name="TQuery">The type of query being handled.</typeparam>
    /// <typeparam name="TResult">The type of returned result from the handler.</typeparam>
    public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        /// <summary>
        ///     Handles a query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task that represents an asynchronous operation. The task result contains the query result.</returns>
        Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default(CancellationToken));
    }
}