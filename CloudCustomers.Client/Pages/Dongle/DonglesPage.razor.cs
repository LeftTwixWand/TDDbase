using System.Net.Http.Json;
using CloudCustomers.Application.Enums;
using CloudCustomers.Application.Requests.Dongles;
using CloudCustomers.Application.Responses.Dongles;
using CloudCustomers.Shared.Wrapper;
using MudBlazor;

namespace CloudCustomers.Client.Pages.Dongle;

public partial class DonglesPage
{
    private readonly List<string> _listOfSerialNumber = new()
    {
        "Xqwe123", "qwr12421", "swqrwq231"
    };

    private readonly string _searchString = "";

    private readonly bool bordered = false;

    private readonly bool dense = false;
    private readonly bool hover = true;
    private readonly bool striped = false;
    private IEnumerable<DongleInformationResponse> _table;
    private string searchString = "";

    private HttpClient httpClient;

    private bool isOpen;
    // [Inject] private IDongleManager DongleManager { get; set; }

    private IResult<IEnumerable<DongleInformationResponse>> Dongles { get; set; }


    protected override async Task OnInitializedAsync()
    {
        _table = new List<DongleInformationResponse>
        {
            new()
            {
                Expiration = DateTime.Now.AddHours(2),
                DealerСompany = "My Dealer",
                ProductName = ProductsEnum.AcPro,
                ProductId = 12,
                SerialNumber = "qrtwqrwq"
            }
        };
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

    private void ServerReload(TableState state)
    {
        if (!string.IsNullOrWhiteSpace(_searchString)) state.Page = 0;

        LoadData(state.Page, state.PageSize, state);
    }

    private async Task LoadData(int statePage, int statePageSize, TableState state)
    {
        var request = new GetDongleBySerialRequest
            { PageSize = statePageSize, PageNumber = statePage + 1, SearchString = _searchString };
    }


    private void OpenDialog()
    {
        DialogService.Show<DongleAlert>("Choose an action");
    }
}