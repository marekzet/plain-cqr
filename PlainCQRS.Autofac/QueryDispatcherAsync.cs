using Autofac;
using PlainCQRS.Core.Common;
using PlainCQRS.Core.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Autofac
{
    public class QueryDispatcherAsync : IQueryDispatcherAsync
    {
        private readonly IComponentContext componentContext;

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