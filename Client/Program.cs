using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args)
    .AddRootComponents()
    .AddClientServices();

await builder.Build().RunAsync();