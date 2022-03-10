using CloudCustomers.Server.Controllers;
using CloudCustomers.Domain.Entity.Dongle;
using CloudCustomers.Infrastructure.Services;
using CloudCustomers.Server.Tests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using static Moq.Times;

namespace CloudCustomers.Server.Tests.Server.Controllers;

public class UnitTest1
{
    
    #region Get All Dongles
    [Fact]
    public async Task GetOnNotOkResult()
    {
        // Arrange
        var mockDongleService = new Mock<IDongleService>();

        mockDongleService
            .Setup(services => services.GetAllDongles())
            .ReturnsAsync(DongleFixture.GetTestDongles());

        var objectOfController = new DongleController(mockDongleService.Object);

        // Act
        var result = await objectOfController.GetAllDongles();
        // Assert 

        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.StatusCode.Should().Be(200);
    }
    [Fact]
    public async Task GetOnSuccessInvokeDongleService()
    {
        // Arrange
        var mockDongleService = new Mock<IDongleService>();
        mockDongleService
            .Setup(services => services.GetAllDongles())
            .ReturnsAsync(DongleFixture.GetTestDongles());

        var sut = new DongleController(mockDongleService.Object);

        // Act
        var result = await sut.GetAllDongles();
        // Assert 
        mockDongleService.Verify(service => service.GetAllDongles(), Once);
    }
    [Fact]
    public async Task GetOnSuccessListOfUsers()
    {
        // Arrange
        var mockDongleService = new Mock<IDongleService>();

        mockDongleService
            .Setup(services => services.GetAllDongles())
            .ReturnsAsync(DongleFixture.GetTestDongles());

        var objectOfController = new DongleController(mockDongleService.Object);

        // Act
        var result = await objectOfController.GetAllDongles();
        // Assert 

        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<Dongle>>();
    }
    [Fact]
    public async Task GetOnNotFoundResult()
    {
        // Arrange
        var mockDongleService = new Mock<IDongleService>();

        mockDongleService
            .Setup(services => services.GetAllDongles())
            .ReturnsAsync(DongleFixture.GetTestDongles());

        var objectOfController = new DongleController(mockDongleService.Object);

        // Act
        var result = await objectOfController.GetAllDongles();
        // Assert 

        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }
    
    #endregion

}