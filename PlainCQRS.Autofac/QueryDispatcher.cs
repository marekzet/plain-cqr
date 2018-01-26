using Autofac;
using PlainCQRS.Core.Common;
using PlainCQRS.Core.Queries;

namespace PlainCQRS.Autofac
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext componentContext;

        public QueryDispatcher(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            var genericType = typeof(IQueryHandler<,>);
            var closedGeneric = genericType.MakeGenericType(query.GetType(), typeof(TResult));
            object handler;
            if (componentContext.TryResolve(closedGeneric, out handler))
            {
                var result = handler
                    .GetType()
                    .GetMethod("Handle", new[] { query.GetType() })
                    .Invoke(handler, new object[] { query });

                return (TResult)result;
            }

            throw new HandlerNotFoundException($"Handler not found for query: {query.GetType()}");
        }
    }
}