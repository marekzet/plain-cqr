using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Core.Queries
{
    /// <summary>
    ///     Defines an asynchronous dispatcher for queries.
    /// </summary>
    public interface IQueryDispatcherAsync
    {
        /// <summary>
        ///     Asynchronously sends query to single handler.
        /// </summary>
        /// <typeparam name="TResult">Query result type.</typeparam>
        /// <param name="query">Query object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A task that represents an asynchronous operation. The task result contains the query result.</returns>
        Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query, 
            CancellationToken cancellationToken = default(CancellationToken));
    }
}