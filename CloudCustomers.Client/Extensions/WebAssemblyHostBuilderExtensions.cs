using CloudCustomers.Client.Infrastructure.Managers;
using CloudCustomers.Client.Infrastructure.Managers.Dongle;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MudBlazor;
using MudBlazor.Services;

namespace CloudCustomers.Client.Extensions;

public static class WebAssemblyHostBuilderExtensions
{
    public static WebAssemblyHostBuilder AddRootComponents(this WebAssemblyHostBuilder builder)
    {
        var root = builder.RootComponents;
        root.Add<App>("#app");
        root.Add<HeadOutlet>("head::after");
        return builder;
    }

    public static WebAssemblyHostBuilder AddClientServices(this WebAssemblyHostBuilder builder)
    {
        var services = builder.Services;
        services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; })
            .AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            })
            .AddMudServices(configuration =>
            {
                configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                configuration.SnackbarConfiguration.HideTransitionDuration = 100;
                configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
                configuration.SnackbarConfiguration.VisibleStateDuration = 3000;
                configuration.SnackbarConfiguration.ShowCloseIcon = false;
            })
            .AddManagers();
        
        return builder;
    }

    public static IServiceCollection AddManagers(this IServiceCollection services)
    {
        var managers = typeof(IManager);

        var types = managers
            .Assembly
            .GetExportedTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Select(t => new
            {
                Service = t.GetInterface($"I{t.Name}"),
                Implementation = t
            })
            .Where(t => t.Service != null);

        foreach (var type in types)
        {
            if (managers.IsAssignableFrom(type.Service))
                services.AddTransient(type.Service, type.Implementation);
        }

        return services;
    }
    
}