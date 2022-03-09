using System.Net;
using CloudCustomers.Client.Infrastructure.Routes;
using CloudCustomers.Domain.Entity;
using CloudCustomers.Domain.Entity.Dongle;

namespace CloudCustomers.API.Services;

public class DongleService : IDongleService
{
    private readonly HttpClient _httpClient;

    public DongleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Dongle>> GetAllDongles()
    {
        var usersResponse = await _httpClient
            .GetAsync(DongleRoutes.GetAllDongles);
        if (usersResponse.StatusCode.Equals(HttpStatusCode.NotFound)) return new List<Dongle>();
        var responseContent = usersResponse.Content;
        var allUsers = await responseContent.ReadFromJsonAsync<List<Dongle>>();
        if (allUsers is null) return allUsers;
        return allUsers.ToList();
    }

    public async Task<Dongle> GetDongleById(string serial)
    {
      var userResponse =  await _httpClient.GetAsync(DongleRoutes.GetDongleBySerial(serial));
      if (userResponse.StatusCode.Equals(HttpStatusCode.NotFound)) return new Dongle();
      var responseContent = userResponse.Content;
      var userBySerial = await responseContent.ReadFromJsonAsync<Dongle>();
      return userBySerial;
    }
}