using CloudCustomers.Infrastructure.Services;

namespace CloudCustomers.Server.Extensions;

public static class ApiServices
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        var services = builder.Services;
        services.AddTransient<IDongleService, DongleService>();
        services.AddHttpClient<IDongleService, DongleService>();
    }
}