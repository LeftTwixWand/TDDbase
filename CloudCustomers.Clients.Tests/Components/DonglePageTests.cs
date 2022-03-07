using AngleSharp.Dom;
using Bunit;
using CloudCustomers.Client.Pages;
using CloudCustomers.Client.Pages.Dongle;

namespace CloudCustomers.Clients.Tests.Components;

public class DonglePageTests
{
    [Fact]
    public void InformationShouldViewWhenSelectedDongle()
    {
        // Arrange
        using var context = new TestContext();
        var renderComponent = context.RenderComponent<DonglesPage>();
        var element = renderComponent.Find("mud-expand-panel mud-panel-expanded mud-elevation-1 mud-expand-panel-border");
        
        // Act
        renderComponent.Find("button").Click();
        var ListOfSerialNumbers = element.AwaitEventAsync("").Result;
        
        // Assert
        ListOfSerialNumbers;
    }
}