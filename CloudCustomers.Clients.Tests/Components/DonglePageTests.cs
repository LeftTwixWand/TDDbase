using Bunit;
using CloudCustomers.Client.Pages.Dongle;
using CloudCustomers.Clients.Tests.Extensions;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;

namespace CloudCustomers.Clients.Tests.Components;

public class DonglePageTests
{
    [Fact]
    public void DongleInformationShouldBeNotNull()
    {
        // Arrange
        using var context = new TestContext();
        
        MudBlazorExtensions.AddMudBlazorServices(context);
        
        context.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
        
        var renderComponent = context.RenderComponent<DonglesPage>();
        var table = context.RenderComponent<DongleDataTable>();
        
        // Act
        renderComponent.Find("button").Click();

        // Assert
        Assert.NotNull(table.Instance.ChosenDongle);
    }
}