using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq.Protected;
using System.Net;

namespace DemoDualAPITesting
{
    internal class IpInfoServiceTests
    {
        public async Task GetCityAsync_ReturnsCorrectCity()
        {
            //Arrange
            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler
                .Protected()
                .Setup(< Task >
                    "SendAsync"
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                    )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\city\": \"test-city\"}");
                });
        HttpClient mockClient = new HttpClient(mockHandler.Object);
        IpInfoServiceTests service = new IpInfoServiceTests(mockClient);

        //Act
        string result = await IpInfoServiceTests.GetCityAsync("1.1.1.1");

        //Assert
        Assert.AreEqual("test-city", result);
        }
    }
}
