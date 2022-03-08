using CloudCustomers.Application.Responses.Dongles;
using Microsoft.AspNetCore.Components;

namespace CloudCustomers.Client.Pages.Dongle;

public partial class DongleDataTable
{
    [Parameter] public List<DongleInformationResponse> ChosenDongle { get; set; }
    private readonly bool _bordered = false;
    private readonly bool _dense = false;
    private readonly bool _hover = true;
    private readonly bool _striped = false;
    private string _searchString = "";
    
    protected override void OnInitialized()
    {
        ChosenDongle = new List<DongleInformationResponse>();
    }
    private bool FilterFunc1(DongleInformationResponse element)
    {
        return FilterFunc(element, _searchString);
    }

    private bool FilterFunc(DongleInformationResponse element, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (element.DealerСompany.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }
    
}