using PlainCQRS.Core.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace PlainCQRS.Autofac.Tests.Queries
{
    public class TestQueryHandlerAsync : IQueryHandlerAsync<TestQuery, string>
    {
        public Task<string> HandleAsync(TestQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(query.Text);
        }
    }
}