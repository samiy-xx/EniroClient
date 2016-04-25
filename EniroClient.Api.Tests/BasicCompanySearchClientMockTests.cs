using System;
using System.Net.Http;
using System.Threading.Tasks;
using EniroClient.Api.Clients;
using EniroClient.Api.Utils;
using EniroClient.Common.Dto;
using Moq;
using NUnit.Framework;

namespace EniroClient.Api.Tests
{
    [TestFixture]
    public class BasicCompanySearchClientMockTests
    {
        private IBasicCompanySearchClient client;

        private Mock<IQueryParameterBuilder> queryParameterBuilderMock;
        private Mock<ISearchHttpClient> searchHttpClientMock;

        private IQueryParameterBuilder queryParameterBuilder;
        private ISearchHttpClient searchHttpClient;

        [SetUp]
        public void Setup()
        {
            queryParameterBuilderMock = new Mock<IQueryParameterBuilder>();
            queryParameterBuilderMock.Setup(x => x.Build()).Returns("?test=1&test2=2");
            queryParameterBuilder = queryParameterBuilderMock.Object;

            searchHttpClientMock = new Mock<ISearchHttpClient>();
            searchHttpClient = searchHttpClientMock.Object;

            client = new BasicCompanySearchClient(searchHttpClient, queryParameterBuilder, "someurl", 5, "testProfile", "apiKey", "1.1.3", "no");
        }

        [Test]
        public async void Test()
        {
            searchHttpClientMock.Setup(x => x.GetAsync(It.IsAny<Uri>())).Returns(GenResponse);
            var r = await client.SearchById("someid");
            Assert.IsNotNull(r);
            Assert.IsInstanceOf<ApiResult<EniroResult>>(r);
        }

        private Task<HttpResponseMessage> GenResponse()
        {
            return Task.FromResult<HttpResponseMessage>(TestFactory.GenOkResponseMessage());
        }
    }
}
