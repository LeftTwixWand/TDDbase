

using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services;

public class LicensesService : ILicensesService
{
    private readonly HttpClient _httpClient;
    public LicensesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<License>> GetAllLicenses()
    {
        var usersResponse = await _httpClient.GetAsync("https://example.com");
        return new List<License>{};
    }
    
}