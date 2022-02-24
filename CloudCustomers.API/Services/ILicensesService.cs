

using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services;

public interface ILicensesService
{
    public Task<List<License>> GetAllLicenses();
}