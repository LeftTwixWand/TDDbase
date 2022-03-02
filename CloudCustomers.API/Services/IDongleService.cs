using CloudCustomers.Domain.Entity;

namespace CloudCustomers.API.Services;

public interface IDongleService
{
    public Task<List<Dongle>?> GetAllDongles();
    public Task<Dongle?> GetDongleById(string id);
}