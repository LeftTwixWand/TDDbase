using CloudCustomers.Domain.Entity;
using CloudCustomers.Domain.Entity.Dongle;

namespace CloudCustomers.API.Services;

public interface IDongleService
{
    public Task<List<Dongle>?> GetAllDongles();
    public Task<Dongle?> GetDongleById(string id);
}