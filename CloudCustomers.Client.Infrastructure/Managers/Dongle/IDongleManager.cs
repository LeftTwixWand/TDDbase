using System.Collections.Generic;
using System.Threading.Tasks;
using CloudCustomers.Application.Responses;
using CloudCustomers.Application.Responses.Dongles;
using CloudCustomers.Shared.Wrapper;

namespace CloudCustomers.Client.Infrastructure.Managers.Dongle;

public interface IDongleManager
{
    Task<IResult<IEnumerable<DongleInformationResponse>>> GetCurrentUserDonglesAsync();
    Task<IResult<DongleInformationResponse>> GetCurrentUserDongleBySerialAsync(string serialId);
}