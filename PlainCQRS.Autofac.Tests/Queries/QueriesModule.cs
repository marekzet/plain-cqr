using Autofac;
using PlainCQRS.Core.Queries;

namespace PlainCQRS.Autofac.Tests.Queries
{
    public class QueriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var threadSpecificContext = c.Resolve<IComponentContext>();
                return new QueryDispatcher(threadSpecificContext);
            })
            .As<IQueryDispatcher>()
            .InstancePerDependency();

            builder.Register(c =>
            {
                var threadSpecificContext = c.Resolve<IComponentContext>();
                return new QueryDispatcherAsync(threadSpecificContext);
            })
            .As<IQueryDispatcherAsync>()
            .InstancePerDependency();

            builder.RegisterType<TestQueryHandler>().As<IQueryHandler<TestQuery, string>>();
            builder.RegisterType<TestQueryHandlerAsync>().As<IQueryHandlerAsync<TestQuery, string>>();
        }
    }
}