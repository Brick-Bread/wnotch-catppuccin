# Notch Catppuccin

A theme plugin for [Brick-Bread/WNotch](https://github.com/Brick-Bread/WNotch), built against its supported **plugin API 6**. Version 0.2.0 includes the four Catppuccin flavors and one Minecraft-inspired theme:

- **Catppuccin / Latte:** soft light palette with rosewater and mauve accents.
- **Catppuccin / Frappe:** cool mid-dark palette with sapphire accents.
- **Catppuccin / Macchiato:** deep palette with mauve accents.
- **Catppuccin / Mocha:** rich dark palette with lavender accents.
- **Minecraft:** blocky grass, dirt, stone and diamond colours using the bundled `MinecraftDefault-Regular.ttf` font from [tryashtar/minecraft-ttf](https://github.com/tryashtar/minecraft-ttf).

The themes cover the compact pill, expanded shell, cards, shared buttons, tab strip, text inputs, fonts, radii, progress tracks and terminal palette. The existing layout, interactions and activity glows remain controlled by Notch.

## Install

In WNotch Settings, under **Plugins**, enter `Brick-Bread/wnotch-catppuccin` and press **Install**, then save. Select a **Catppuccin** variant under **Plugin theme** and save again. Requires WNotch with plugin API 6 or newer.

Alternatively, download `notch-catppuccin-0.2.0.zip` from [Releases](https://github.com/Brick-Bread/wnotch-catppuccin/releases), extract it into `%AppData%\Notch\plugins\brick-bread.catppuccin`, then enable **Notch Catppuccin** in Settings.

## Build

Requires the .NET 10 SDK and a WNotch build with API 6 or newer. The default reference is the installed `%LocalAppData%\Programs\Notch\Notch.Core.dll`.

```powershell
Set-Location 'path\to\wnotch-catppuccin'
.\build.ps1
```

For a different installation or source build:

```powershell
.\build.ps1 -NotchCorePath 'C:\path\to\Notch.Core.dll'
```

This creates `dist\brick-bread.catppuccin` and `dist\notch-catppuccin-0.2.0.zip`. The plugin does not ship `Notch.Core.dll`, use NuGet packages, poll, access the network or alter saved application settings. Its entry point only registers themes.

## Try in Notch

Quit the running installed copy from its tray menu, then launch a development run from this folder:

```powershell
& "$env:LOCALAPPDATA\Programs\Notch\Notch.exe" "--plugin=$PWD\dist\brick-bread.catppuccin" --plugin-theme=brick-bread.catppuccin/mocha --pin-open --tab=stats
```

Use `latte`, `frappe`, `macchiato`, `mocha` or `minecraft` as the theme id. The development flags do not save your theme choice. This script does not automatically quit or change your running Notch.

To install permanently, copy `dist\brick-bread.catppuccin` into `%AppData%\Notch\plugins`, enable **Notch Catppuccin** in Settings and save. Select a **Catppuccin** variant under **Plugin theme** and save again. Disabling the plugin lets Notch restore the normal theme.

## Validate and Preview

```powershell
dotnet run --project tools\ThemeCheck -- dist\brick-bread.catppuccin artifacts
```

The native WPF checker loads the shipped dictionaries, checks supported resource types and opaque terminal colours, measures text contrast over black and white desktops, and renders preview PNGs into `artifacts`. It exercises real control templates in a sample layout; it is not an end-to-end test of the running Notch. It also checks theme registration through the installed plugin interface and verifies that the package excludes the host DLL.

## Theme Files

- `CatppuccinThemePlugin.cs`: registers all four themes with the host.
- `plugin.json`: the real Notch plugin manifest.
- `themes/latte.xaml`, `themes/frappe.xaml`, `themes/macchiato.xaml`, `themes/mocha.xaml` and `themes/minecraft.xaml`: surface and terminal palettes.
- `themes/controls.xaml`: shared fonts, radii and supported control styles.
- `fonts/MinecraftDefault-Regular.ttf`: bundled MinecraftDefault font used by the Minecraft theme.

## Releases

GitHub Actions builds and validates the plugin on pushes to `main` and pull requests. Pushing a matching version tag, such as `v0.2.0`, creates a release with exactly one plugin ZIP, which WNotch's installer expects. The workflow pins the WNotch source used for its API reference; local builds use the installed host DLL by default.

## License

MIT. See [LICENSE](LICENSE).
