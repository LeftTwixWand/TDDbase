using System.Collections.Generic;
using CloudCustomers.Domain.Entity;
using CloudCustomers.Domain.Entity.Dongle;

namespace CloudCustomers.Application.Responses.Dongles;

public class GetAllDongles
{
    public List<Dongle> Dongles { get; set; }
}