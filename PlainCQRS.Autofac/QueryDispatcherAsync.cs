using Autofac;
using PlainCQRS.Core.Common;
using PlainCQRS.Core.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Autofac
{
    /// <summary>
    ///     Default implementation of asynchronous dispatcher for queries.
    /// </summary>
    public class QueryDispatcherAsync : IQueryDispatcherAsync
    {
        private readonly IComponentContext componentContext;

        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryDispatcherAsync"/> class.
        /// </summary>
        /// <param name="componentContext">The context in which a service can be accessed or a component's dependencies resolved.</param>
        public QueryDispatcherAsync(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public async Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var asyncGenericType = typeof(IQueryHandlerAsync<,>);
            var closedAsyncGeneric = asyncGenericType.MakeGenericType(query.GetType(), typeof(TResult));
            object asyncHandler;
            if (componentContext.TryResolve(closedAsyncGeneric, out asyncHandler))
            {
                var result = asyncHandler
                    .GetType()
                    .GetMethod("HandleAsync", new[] { query.GetType(), typeof(CancellationToken) })
                    .Invoke(asyncHandler, new object[] { query, cancellationToken });

                return await (Task<TResult>)result;
            }

            throw new HandlerNotFoundException($"Handler not found for query: {query.GetType()}");
        }
    }
}