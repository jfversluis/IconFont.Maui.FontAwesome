[![NuGet](https://img.shields.io/nuget/v/IconFont.Maui.FontAwesome.svg?label=NuGet)](https://www.nuget.org/packages/IconFont.Maui.FontAwesome)

# IconFont.Maui.FontAwesome

`IconFont.Maui.FontAwesome` ships the [Font Awesome Free](https://github.com/FortAwesome/Font-Awesome) icon fonts for .NET MAUI. It bundles three styles — **Solid**, **Regular**, and **Brands** — registers them at build time via `buildTransitive` targets, and exposes strongly-typed glyph constants plus helper APIs.

## ✨ Features

- ⚙️ **One-line setup**: call `builder.UseFontAwesome()` in `MauiProgram` to register all three font styles
- 🔤 **Strongly-typed glyphs** via `FontAwesomeSolid.*`, `FontAwesomeRegular.*`, `FontAwesomeBrands.*`
- 🧰 **Helper API**: `FontAwesome.Create()` for quick `FontImageSource` creation
- 📱 **Supported targets**: Android, iOS, Mac Catalyst, Windows

## 📦 Install

```bash
dotnet add package IconFont.Maui.FontAwesome
```

## 🚀 Getting Started

### Register

```csharp
var builder = MauiApp.CreateBuilder()
    .UseMauiApp<App>()
    .UseFontAwesome(); // registers all Font Awesome styles
```

Or register a single style:

```csharp
builder.UseFontAwesomeSolid();
```

### XAML usage

```xaml
xmlns:icons="clr-namespace:IconFont.Maui.FontAwesome;assembly=IconFont.Maui.FontAwesome"

<FontImageSource Glyph="{x:Static icons:FontAwesomeSolid.House}"
                 FontFamily="{x:Static icons:FontAwesome.FontFamily}"
                 Color="#2563EB"
                 Size="32" />
```

### C# usage

```csharp
using IconFont.Maui.FontAwesome;

var source = FontAwesome.Create(FontAwesomeSolid.House, Colors.Orange, 32);
```

> **Tip:** Glyph names follow the upstream Font Awesome naming. Updating the OTF files and rebuilding regenerates the glyph API automatically.

## 📋 Styles & Glyphs

The generator emits one class per style:

| Class | Font File | Description |
|-------|-----------|-------------|
| `FontAwesomeSolid` | `fa-solid-900.otf` | Filled solid icons |
| `FontAwesomeRegular` | `fa-regular-400.otf` | Outlined regular icons |
| `FontAwesomeBrands` | `fa-brands-400.otf` | Brand logos |

## 🧩 Platforms

| Platform | Minimum |
|----------|---------|
| Android  | 21+     |
| iOS      | 15+     |
| macOS    | 15+     |
| Windows  | 10 1809 |

## 📄 License

- **Library:** MIT License (see [`LICENSE`](LICENSE))
- **Font Awesome Free fonts:** SIL Open Font License 1.1 © Fonticons, Inc. See [`NOTICE.md`](NOTICE.md) for attribution and upstream license text.

## 🙏 Attribution

- Font Awesome Free by Fonticons, Inc. — https://fontawesome.com
- Font files licensed under the SIL Open Font License 1.1
- This project is not affiliated with or endorsed by Fonticons, Inc.
