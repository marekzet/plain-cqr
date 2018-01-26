using Autofac;
using Autofac.Core;

namespace PlainCQRS.Autofac.Tests
{
    public class AutofacTest<TModule> where TModule : IModule, new()
    {
        private IContainer container;

        public AutofacTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new TModule());

            container = builder.Build();
        }

        protected TService Resolve<TService>()
        {
            return container.Resolve<TService>();
        }

        protected void CleanUpContainer()
        {
            container.Dispose();
        }
    }
}