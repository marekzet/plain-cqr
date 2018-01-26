using PlainCQRS.Core.Queries;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PlainCQRS.Autofac.Tests.Queries
{
    public class QueryDispatcherTests : AutofacTest<QueriesModule>, IDisposable
    {
        [Fact]
        public void should_execute_query_using_registered_handler_and_return_data()
        {
            var query = new TestQuery("Hello");

            var queryBus = Resolve<IQueryDispatcher>();

            var result = queryBus.Execute(query);

            Assert.IsType<string>(result);
            Assert.Equal("Hello", result);
        }

        [Fact]
        public async Task should_execute_query_asynchronously_using_registered_handler_and_return_data()
        {
            var query = new TestQuery("Hello");

            var queryBus = Resolve<IQueryDispatcherAsync>();

            var result = await queryBus.ExecuteAsync(query);

            Assert.IsType<string>(result);
            Assert.Equal("Hello", result);
        }

        public void Dispose()
        {
            CleanUpContainer();
        }
    }
}