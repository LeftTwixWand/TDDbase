using CloudCustomers.Domain.Entity;
using CloudCustomers.Domain.Entity.Dongle;

namespace CloudCustomers.Server.Tests.Fixtures;

public static class DongleFixture
{
    public static List<Dongle> GetTestDongles()
    {
        return new()
        {
            new Dongle
            {
                DealerId = 1,
                SerialNumber = "00002",
                UserId = 12
            },
            new Dongle 
            {
                DealerId = 2,
                SerialNumber = "155123",
                UserId = 5
            }
        };
    }

    public static Dongle GetTestDongleBySerial()
    {
        
        return new Dongle
        {
            DealerId = 16,
            SerialNumber = "00000008",
            UserId = 14521
        };
    }
}