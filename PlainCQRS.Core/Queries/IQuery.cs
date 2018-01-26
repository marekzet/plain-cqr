namespace PlainCQRS.Core.Queries
{
    /// <summary>
    ///     Marker interface to represent query.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IQuery<out TResult>
    {
    }
}