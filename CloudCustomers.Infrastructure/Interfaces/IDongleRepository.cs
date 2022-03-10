using CloudCustomers.Domain.Entity.Dongle;

namespace CloudCustomers.Infrastructure.Interfaces;

public interface IDongleRepository
{
    Task<IEnumerable<Dongle>> GetAllDongleByUserId(string userId);
    Task<IEnumerable<DongleInformation>> GetDongleInformationBySerialNumber(string serialNumber);
}