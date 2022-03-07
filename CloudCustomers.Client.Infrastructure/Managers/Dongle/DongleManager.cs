
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CloudCustomers.Client.Infrastructure.Extensions;
using CloudCustomers.Application.Responses.Dongles;
using CloudCustomers.Client.Infrastructure.Routes;
using CloudCustomers.Shared.Wrapper;

namespace CloudCustomers.Client.Infrastructure.Managers.Dongle;

public class DongleManager : IDongleManager
{
    private readonly HttpClient _httpClient;

    public DongleManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IResult<IEnumerable<DongleInformationResponse>>> GetCurrentUserDonglesAsync()
    {
        var response = await _httpClient.GetAsync(DongleRoutes.GetAllDongles);
        var result = await response.ToResult<IEnumerable<DongleInformationResponse>>();
        return result;
    }

    public async Task<IResult<DongleInformationResponse>> GetCurrentUserDongleBySerialAsync(string serialId)
    {
     var response =   await _httpClient.GetAsync(DongleRoutes.GetDongleBySerial(serialId));
     return await response.ToResult<DongleInformationResponse>();
    }
    
}