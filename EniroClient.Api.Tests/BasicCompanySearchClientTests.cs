using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EniroClient.Api.Clients;
using NUnit.Framework;

namespace EniroClient.Api.Tests
{
    [TestFixture]
    public class BasicCompanySearchClientTests
    {
        private BasicCompanySearchClient client;

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
