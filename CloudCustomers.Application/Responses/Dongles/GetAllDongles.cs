using System.Collections.Generic;
using CloudCustomers.Domain.Entity;

namespace CloudCustomers.Application.Responses.Dongles;

public class GetAllDongles
{
    public List<Dongle> Dongles { get; set; }
}