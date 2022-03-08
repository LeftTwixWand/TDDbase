using CloudCustomers.Application.Enums;
using CloudCustomers.Application.Requests.Dongles;
using CloudCustomers.Application.Responses.Dongles;
using MudBlazor;

namespace CloudCustomers.Client.Pages.Dongle;

public partial class DonglesPage
{
    private readonly List<string> _listOfSerialNumber = new()
    {
        "Xqwe123", "qwr12421", "swqrwq231"
    };

    private readonly string _searchString = "";
    
    private IEnumerable<DongleInformationResponse> _allDonglesOfUser;
    private List<DongleInformationResponse> _chosenDongle;

    private static bool _showTableLicenses;

    private HttpClient httpClient;

    private bool isOpen;
    
    private string serialNumberActiveDongle = "";


    protected override async Task OnInitializedAsync()
    {
        _allDonglesOfUser = new List<DongleInformationResponse>
        {
            new()
            {
                Expiration = DateTime.Now.AddHours(2),
                DealerСompany = "My Dealer",
                ProductName = ProductsEnum.AcPro,
                ProductId = 12,
                SerialNumber = "X9891452-QWE23-Q21321"
            },
            new()
            {
                Expiration = DateTime.Now.AddHours(3),
                DealerСompany = "New Dealer",
                ProductName = ProductsEnum.Fitness,
                ProductId = 10,
                SerialNumber = "Qrwqreq-QWE23-QZzzz"
            }
        };
        _chosenDongle = new List<DongleInformationResponse>();
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
        DialogService.Show<DongleAlert>("Add dongle");
    }

    private  void ShowInformationAboutDongle(string serialNumber)
    {
        serialNumberActiveDongle = serialNumber;
        foreach (var dongle in _allDonglesOfUser)
            if (serialNumber.Equals(dongle.SerialNumber))
            {
                _chosenDongle.Clear();
                _chosenDongle.Add(dongle);
            }

        _showTableLicenses = true;
    }
}