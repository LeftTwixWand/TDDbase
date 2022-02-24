using CloudCustomers.API.Models;

namespace CloudCustomers.UnitTests.Fixtures;

public static class LicenceFixture
{
    public static List<License> GetTestLicenses() => new()
    {
        new License
        {
            Description = "Test description",
            DealerId = 1,
            DongleId = 2,
            UserId = 12
        },
        new License
        {
            Description = "Test description 2",
            DealerId = 2,
            DongleId = 155123,
            UserId = 5
        },
    };
}