using PlainCQRS.Core.Queries;

namespace PlainCQRS.Autofac.Tests.Queries
{
    public class TestQuery : IQuery<string>
    {
        public TestQuery(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}