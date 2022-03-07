using MudBlazor.ThemeManager;

namespace CloudCustomers.Client.Shared;

public partial class MainLayout
{
    private bool _drawerOpen = true;

    private ThemeManagerTheme _themeManager = new();
    public bool _themeManagerOpen;

    private void OpenThemeManager(bool value)
    {
        _themeManagerOpen = value;
    }

    private void UpdateTheme(ThemeManagerTheme value)
    {
        _themeManager = value;
        StateHasChanged();
    }

    protected override void OnInitialized()
    {
        StateHasChanged();
    }

    private void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }
}