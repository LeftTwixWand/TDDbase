using CloudCustomers.Domain.Entity.Dongle;
using CloudCustomers.Infrastructure.Interfaces;

namespace CloudCustomers.Infrastructure.Repositories;

public class DongleRepository : IDongleRepository
{
    public Task<IEnumerable<Dongle>> GetAllDongleByUserId(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DongleInformation>> GetDongleInformationBySerialNumber(string serialNumber)
    {
        throw new NotImplementedException();
    }
}