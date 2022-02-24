using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using CloudCustomers.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using static Moq.Times;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class UnitTest1
{
    [Fact]
    public async Task GetOnNotOkResult()
    {
        // Arrange
        var mockLicensesService = new Mock<ILicensesService>();

        mockLicensesService
            .Setup(services => services.GetAllLicenses())
            .ReturnsAsync(LicenceFixture.GetTestLicenses());

        var objectOfController = new LicenseController(mockLicensesService.Object);

        // Act
        var result = await objectOfController.GetAllLicense();
        // Assert 

        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.StatusCode.Should().Be(200);
    }
    
    [Fact]
    public async Task GetOnSuccessInvokeLicensesService()
    {
        // Arrange
        var mockLicensesService = new Mock<ILicensesService>();
        mockLicensesService
            .Setup(services => services.GetAllLicenses())
            .ReturnsAsync(LicenceFixture.GetTestLicenses());
        
        var sut = new LicenseController(mockLicensesService.Object);

        // Act
        var result = await sut.GetAllLicense();
        // Assert 
        mockLicensesService.Verify(service=> service.GetAllLicenses(), Once);
    }

    [Fact]
    public async Task GetOnSuccessListOfUsers()
    {
        // Arrange
        var mockLicensesService = new Mock<ILicensesService>();
        
        mockLicensesService
            .Setup(services => services.GetAllLicenses())
            .ReturnsAsync(LicenceFixture.GetTestLicenses());
        
        var objectOfController = new LicenseController(mockLicensesService.Object);

        // Act
        var result = await objectOfController.GetAllLicense();
        // Assert 

        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<License>>();

    }
    
    [Fact]
    public async Task GetOnNotFoundResult()
    {
        // Arrange
        var mockLicensesService = new Mock<ILicensesService>();

        mockLicensesService
            .Setup(services => services.GetAllLicenses())
            .ReturnsAsync(LicenceFixture.GetTestLicenses());

        var objectOfController = new LicenseController(mockLicensesService.Object);

        // Act
        var result = await objectOfController.GetAllLicense();
        // Assert 

        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }
}