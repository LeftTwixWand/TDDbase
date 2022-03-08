using Bunit;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;

namespace CloudCustomers.Clients.Tests.Extensions;

public static class MudBlazorExtensions
{
    public static void AddMudBlazorServices(TestContext context)
    {
        context.JSInterop.Mode = JSRuntimeMode.Loose;
        context.Services.AddTransient<IDialogService, DialogService>();
        context.Services.AddTransient<IKeyInterceptor, KeyInterceptor>();
        context.Services.AddTransient<IScrollManager, ScrollManager>();
        context.Services.AddTransient<IMudPopoverService, MudPopoverService>();
    }
    
 
}