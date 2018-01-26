namespace PlainCQRS.Core.Queries
{
    /// <summary>
    ///     Defines a synchrounous dispatcher for queries.
    /// </summary>
    public interface IQueryDispatcher
    {
        /// <summary>
        ///     Synchronously sends query to a single handler.
        /// </summary>
        /// <typeparam name="TResult">Query result type.</typeparam>
        /// <param name="query">Query object.</param>
        /// <returns>Query result.</returns>
        TResult Execute<TResult>(IQuery<TResult> query);
    }
}