using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using CloudCustomers.UnitTests.Fixtures;
using CloudCustomers.UnitTests.Helpers;
using Moq;
using Moq.Protected;

namespace CloudCustomers.UnitTests.Systems.Services;

public class TestLicenseService
{
    [Fact]
    public async Task GetAllLicensesWhenCalledInvokesHttpGetRequest()
    {
        //Arrange
        var expectedResponse = LicenceFixture.GetTestLicenses();
        var handlerMock = MockHttpMessageHandler<License>.SetupBasicGetResourceList(expectedResponse);
        var httpClient = new HttpClient(handlerMock.Object);
        var sut = new LicensesService(httpClient);
        //Act
        await sut.GetAllLicenses();
        //Assert
        //Verify HTTP request is made!
        handlerMock
            .Protected()
            .Verify(
                "SendAsync", 
            Times.Exactly(1), 
            ItExpr.Is<HttpRequestMessage>(req=>req.Method == HttpMethod.Get),
            ItExpr.IsAny<CancellationToken>()
            );
    }
}