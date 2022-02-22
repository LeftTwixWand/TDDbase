using CloudCustomers.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class UnitTest1
{
    [Fact]
    public async Task GetOnSuccessReturnsStatusCode200()
    {
        // Arrange
        var sut = new TestUserController();
        
        // Act 
        var result = (OkObjectResult) await sut.Get();
        
        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetOnSuccessInvokeService()
    {
        // Arrange
        var sut = new TestUserController();
        
        // Act 
        var result = (OkObjectResult) await sut.Get();
    }
    
}