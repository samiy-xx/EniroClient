using NUnit.Framework;

namespace EniroClient.Api.Tests
{
    [TestFixture]
    public class BasicCompanySearchClientTests
    {
        private IBasicCompanySearchClient client;

        [SetUp]
        public void Setup()
        {
            client = ClientFactory.BasicCompanySearchClient("xxx", "xxx", "no");
        }

        [Test]
        public async void Test()
        {
            var r = await client.Search("Omnicom");
            Assert.IsNotNull(r);
        }
    }
}
