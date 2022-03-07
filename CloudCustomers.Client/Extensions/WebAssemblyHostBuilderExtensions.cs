using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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
        builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; })
            .AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            }).AddMudServices();
        ;

        return builder;
    }
}