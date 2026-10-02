using Notch.Core.Plugins;

namespace Notch.Catppuccin;

public sealed class CatppuccinThemePlugin : INotchPlugin
{
    public void Start(IPluginHost host)
    {
        host.Themes.Set(new PluginTheme
        {
            Id = "latte",
            Name = "Catppuccin / Latte",
            Description = "Soft light Catppuccin palette with rosewater highlights.",
            File = "themes/latte.xaml",
            Base = PluginThemeBase.Light,
        });

        host.Themes.Set(new PluginTheme
        {
            Id = "frappe",
            Name = "Catppuccin / Frappe",
            Description = "Balanced cool Catppuccin palette with sapphire highlights.",
            File = "themes/frappe.xaml",
            Base = PluginThemeBase.Dark,
        });

        host.Themes.Set(new PluginTheme
        {
            Id = "macchiato",
            Name = "Catppuccin / Macchiato",
            Description = "Deep Catppuccin palette with mauve highlights.",
            File = "themes/macchiato.xaml",
            Base = PluginThemeBase.Dark,
        });

        host.Themes.Set(new PluginTheme
        {
            Id = "mocha",
            Name = "Catppuccin / Mocha",
            Description = "Rich Catppuccin palette with lavender highlights.",
            File = "themes/mocha.xaml",
            Base = PluginThemeBase.Dark,
        });
    }

    public void Stop() { }
}
