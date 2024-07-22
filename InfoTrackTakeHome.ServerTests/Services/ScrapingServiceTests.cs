using InfoTrackTakeHome.Server.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;

namespace InfoTrackTakeHome.Server.Services.Tests
{
    [TestClass()]
    public class ScrapingServiceTests
    {
        [TestMethod]
        public async Task GetGoogleSearchResults_ShouldReturnPositions_WhenUrlIsFound()
        {
            // Arrange
            var searchPhrase = "example search";
            var url = "example.com";
            var htmlContent = @"<div class=""egMi0 kCrYT""><a href=""http://example.com"">Example</a></div>";

            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(htmlContent),
               })
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object);
            var service = new ScrapingService(httpClient);

            // Act
            var result = await service.GetGoogleSearchResults(searchPhrase, url);

            // Assert
            Assert.AreEqual("1", result);
            handlerMock.Protected().Verify(
               "SendAsync",
               Times.Exactly(1),
               ItExpr.Is<HttpRequestMessage>(req =>
                  req.Method == HttpMethod.Get
               ),
               ItExpr.IsAny<CancellationToken>()
            );
        }

        [TestMethod]
        public async Task GetGoogleSearchResults_ShouldReturnZero_WhenUrlIsNotFound()
        {
            // Arrange
            var searchPhrase = "example search";
            var url = "www.example.com";
            var htmlContent = @"<div class=""BNeawe AP7Wnd""><a href=""https://www.anotherexample.com"">Another Example</a></div>";

            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(htmlContent),
               })
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object);
            var service = new ScrapingService(httpClient);

            // Act
            var result = await service.GetGoogleSearchResults(searchPhrase, url);

            // Assert
            Assert.AreEqual("0", result);
            handlerMock.Protected().Verify(
               "SendAsync",
               Times.Exactly(1),
               ItExpr.Is<HttpRequestMessage>(req =>
                  req.Method == HttpMethod.Get
               ),
               ItExpr.IsAny<CancellationToken>()
            );
        }

        [TestMethod]
        public void ParseGoogleSearchResults_ShouldReturnCorrectPositions()
        {
            // Arrange
            var htmlContent = @"<div class=""egMi0 kCrYT""><a href=""http://www.example.com"">Example</a></div>
                                <div class=""egMi0 kCrYT""><a href=""http://www.anotherexample.com"">Another Example</a></div>
                                <div class=""egMi0 kCrYT""><a href=""http://www.example.com/page"">Example Page</a></div>";
            var url = "www.example.com";
            var service = new ScrapingService(new HttpClient());

            // Act
            var result = service.ParseGoogleSearchResults(htmlContent, url);
            // Assert
            CollectionAssert.AreEqual(new List<int> { 1, 3 }, result);
        }

        [TestMethod]
        public void ParseGoogleSearchResults_ShouldReturnEmptyList_WhenUrlIsNotFound()
        {
            // Arrange
            var htmlContent = @"<div class=""BNeawe vvjwJb AP7Wnd""><a href=""http://anotherexample.com"">Another Example</a></div>";
            var url = "example.com";
            var service = new ScrapingService(new HttpClient());

            // Act
            var result = service.ParseGoogleSearchResults(htmlContent, url);

            // Assert
            Assert.AreEqual(0, result.Count);
        }
    }
}