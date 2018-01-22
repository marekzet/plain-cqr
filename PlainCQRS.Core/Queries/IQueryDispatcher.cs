namespace PlainCQRS.Core.Queries
{
    public interface IQueryDispatcher
    {
        TResult Execute<TResult>(IQuery<TResult> query);
    }
}