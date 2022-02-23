using CloudCustomers.API.Services;

namespace CloudCustomers.API.Extensions;

public static class ApiServices
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ILicensesService, LicensesService>();
    }

}