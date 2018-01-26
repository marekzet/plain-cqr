using PlainCQRS.Core.Queries;

namespace PlainCQRS.Autofac.Tests.Queries
{
    public class TestQueryHandler : IQueryHandler<TestQuery, string>
    {
        public string Handle(TestQuery query)
        {
            return query.Text;
        }
    }
}