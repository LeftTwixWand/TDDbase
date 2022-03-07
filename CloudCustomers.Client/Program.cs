
using CloudCustomers.Client.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args)
    .AddRootComponents()
    .AddClientServices();

await builder.Build().RunAsync();