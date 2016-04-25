using EniroClient.Api.Utils;
using NUnit.Framework;

namespace EniroClient.Api.Tests
{
    [TestFixture]
    public class QueryParameterBuilderTests
    {
        private IQueryParameterBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new QueryParameterBuilder();
            builder.Add("foo", "bar");
            builder.Add("a", "b");
        }

        [Test]
        public void BuildReturnsString()
        {
            Assert.IsInstanceOf<string>(builder.Build());
        }

        [Test]
        public void CanAddToBuilder()
        {
            var result = builder.Build();
            Assert.AreEqual("?foo=bar&a=b", result);
        }

        [Test]
        public void CanBeCleared()
        {
            builder.Clear();
            var result = builder.Build();
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }
    }
}
