using CloudCustomers.API.Services;
using CloudCustomers.Client.Infrastructure.Routes;
using CloudCustomers.Domain.Entity;
using CloudCustomers.Domain.Entity.Dongle;
using CloudCustomers.Server.Tests.Fixtures;
using CloudCustomers.Server.Tests.Helpers;
using FluentAssertions;
using Moq;
using Moq.Protected;

namespace CloudCustomers.Server.Tests.Server.Services;

public class TestDongleService
{
    #region Get All Dongles
    [Fact]
    public async Task GetAllDonglesWhenCalledInvokesHttpGetRequest()
    {
        //Arrange
        var expectedResponse = DongleFixture.GetTestDongles();
        var handlerMock = MockHttpMessageHandler<Dongle>.SetupBasicGetResourceList(expectedResponse, DongleRoutes.GetAllDongles);
        var httpClient = new HttpClient(handlerMock.Object);
        var sut = new DongleService(httpClient);
        //Act
        await sut.GetAllDongles();
        //Assert
        //Verify HTTP request is made!
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>()
            );
    }
    [Fact]
    public async Task GetAllDonglesWhenHits404ReturnsEmptyListOfDongles()
    {
        //Arrange
        var handlerMock = MockHttpMessageHandler<Dongle>.SetupReturn404();
        var httpClient = new HttpClient(handlerMock.Object);
        
        var sut = new DongleService(httpClient);
        //Act
        var result = await sut.GetAllDongles();
        //Assert

        result.Count.Should().Be(0);
    }
    [Fact]
    public async Task GetAllDonglesWhenHits404ReturnsEmptyDongle()
    {
        //Arrange
        var handlerMock = MockHttpMessageHandler<Dongle>.SetupReturn404();
        var httpClient = new HttpClient(handlerMock.Object);

        var sut = new DongleService(httpClient);
        //Act
        var result = await sut.GetAllDongles();
        //Assert

        result.Count.Should().Be(0);
    }
    [Fact]
    public async Task GetAllDonglesWhenCalledReturnsListOfUsersOfExpectedSize()
    {
        //Arrange
        var expectedResponse = DongleFixture.GetTestDongles();
        var handlerMock = MockHttpMessageHandler<Dongle>.SetupBasicGetResourceList(expectedResponse, DongleRoutes.GetAllDongles);
        var httpClient = new HttpClient(handlerMock.Object);
        
        var sut = new DongleService(httpClient);
        //Act
        var result = await sut.GetAllDongles();
        //Assert

        result?.Count.Should().Be(expectedResponse.Count);
    }
    [Fact]
    public async Task GetAllDonglesWhenCalledInvokesConfiguredExternalUrl()
    {
        //Arrange
        var expectedResponse = DongleFixture.GetTestDongles();
        var handlerMock = MockHttpMessageHandler<Dongle>
            .SetupBasicGetResourceList(expectedResponse, DongleRoutes.GetAllDongles);
        

        var httpClient = new HttpClient(handlerMock.Object);

        var sut = new DongleService(httpClient);
        //Act
        await sut.GetAllDongles();
        var uri = new Uri(DongleRoutes.GetAllDongles);
        //Assert

        handlerMock
            .Protected()
            .Verify(
                "SandAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    req =>
                        req.Method == HttpMethod.Get &&
                        req.RequestUri == uri),
                ItExpr.IsAny<CancellationToken>()
            );
    }
    
    #endregion
    
    [Fact]
    public async Task GetDongleBySerialWhenCalledInvokesHttpGetRequest()
    {
        //Arrange
        var expectedResponse = DongleFixture.GetTestDongleBySerial();
        var handlerMock = MockHttpMessageHandler<Dongle>.SetupBasicGetResource(expectedResponse);
        var httpClient = new HttpClient(handlerMock.Object);
        var sut = new DongleService(httpClient);

        //Act
        await sut.GetDongleById("1");
        
        //Assert
        handlerMock
            .Protected()
            .Verify("SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>());
    }
    
}