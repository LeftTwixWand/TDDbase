using CloudCustomers.Domain.Entity;

namespace CloudCustomers.Server.Tests.Fixtures;

public static class DongleFixture
{
    public static List<Dongle> GetTestDongles()
    {
        return new()
        {
            new Dongle
            {
                Description = "Test description",
                DealerId = 1,
                Serial = "00002",
                UserId = 12
            },
            new Dongle
            {
                Description = "Test description 2",
                DealerId = 2,
                Serial = "155123",
                UserId = 5
            }
        };
    }

    public static Dongle GetTestDongleBySerial()
    {
        return new Dongle
        {
            Description = "Single",
            DealerId = 16,
            Serial = "00000008",
            UserId = 14521
        };
    }
}