using CloudCustomers.Domain.Entity.Dongle;

namespace CloudCustomers.Infrastructure.Services;

public interface IDongleService
{
    public Task<List<Dongle>?> GetAllDongles();
    public Task<Dongle?> GetDongleById(string id);
}