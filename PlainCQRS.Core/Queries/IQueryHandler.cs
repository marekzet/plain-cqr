namespace PlainCQRS.Core.Queries
{
    /// <summary>
    ///     Defines a handler that synchronously handles a query.
    /// </summary>
    /// <typeparam name="TQuery">The type of query being handled.</typeparam>
    /// <typeparam name="TResult">The type of returned result from the handler.</typeparam>
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        /// <summary>
        ///     Handles a query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Query result.</returns>
        TResult Handle(TQuery query);
    }
}