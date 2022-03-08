using System.Net;
using System.Net.Http.Headers;
using CloudCustomers.Domain.Entity;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;

namespace CloudCustomers.Server.Tests.Helpers;

internal static class MockHttpMessageHandler<T>
{
    #region Setup Basic Get Resource List
    
    public static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<Dongle> expectedResponse, string endpoint)
    {
        var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
        };
        mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var httpRequestMessage = new HttpRequestMessage
        {
            RequestUri = new Uri(endpoint),
            Method = HttpMethod.Get
        };

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                httpRequestMessage,
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(mockResponse);
        return handlerMock;
    }

    #endregion

    #region Setup Basic Get Resource

    public static Mock<HttpMessageHandler> SetupBasicGetResource(Dongle expectedResponse)
    {
        var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
        };
        mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(mockResponse);
        return handlerMock;
    }

    #endregion

    public static Mock<HttpMessageHandler> SetupReturn404()
    {
        var mockResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
        {
            Content = new StringContent("")
        };
        mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(mockResponse);
        return handlerMock;
    }
}