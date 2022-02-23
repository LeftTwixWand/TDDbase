using CloudCustomers.API.Controllers;
using CloudCustomers.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using static Moq.Times;
using License = System.ComponentModel.License;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class UnitTest1
{
    [Fact]
    public async Task GetOnSuccessInvokeLicensesService()
    {
        // Arrange
        var mockLicensesService = new Mock<ILicensesService>();
        mockLicensesService
            .Setup(services => services.GetAllLicenses())
            .ReturnsAsync(new List<License>());
        
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
            .ReturnsAsync(new List<License>());
        
        var objectOfController = new LicenseController(mockLicensesService.Object);

        // Act
        var result = await objectOfController.GetAllLicense();
        // Assert 

        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<License>>();

    }
}