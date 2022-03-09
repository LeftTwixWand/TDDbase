using Bunit;
using CloudCustomers.Client.Pages.Dongle;
using CloudCustomers.Clients.Tests.Extensions;

namespace CloudCustomers.Clients.Tests.Components;

public class DonglePageTests
{
    [Fact]
    public void DongleInformationShouldBeNotNull()
    {
        // Arrange
        using var context = new TestContext();
        MudBlazorExtensions.AddMudBlazorServices(context);


        var renderComponent = context.RenderComponent<DonglesPage>();
        var table = context.RenderComponent<DongleDataTable>();

        // Act
        renderComponent.Find("button").Click();

        // Assert
        Assert.NotNull(table.Instance.ChosenDongle);
    }

    [Fact]
    public void ViewDongleTableWhenWillClickOnSerialNumber()
    {
        // Arrange
        using var context = new TestContext();
        MudBlazorExtensions.AddMudBlazorServices(context);
        var renderComponent = context.RenderComponent<DongleDataTable>();
        
        // Assert
        renderComponent.Find("table")
            .MarkupMatches(
                "<table class=\"mud-table-root\">" +
                "<thead class=\"mud-table-head\">" +
                "<tr class=\"mud-table-row\">" +
                "<th scope=\"col\" class=\"mud-table-cell\">" +
                "Serial Number" +
                "</th>" +
                "<th scope=\"col\" class=\"mud-table-cell\">" +
                "Product Name" +
                "</th>" +
                "<th scope=\"col\" class=\"mud-table-cell\">" +
                "Dealer Company</th>" +
                "<th scope=\"col\" class=\"mud-table-cell\">" +
                "Expiration" +
                "</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody class=\"mud-table-body\">" +
                "</tbody></table>");
    }
}