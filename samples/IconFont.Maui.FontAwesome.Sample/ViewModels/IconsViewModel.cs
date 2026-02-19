using System.Collections.ObjectModel;
using System.Reflection;
using IconFont.Maui.FontAwesome;

namespace IconFont.Maui.FontAwesome.Sample.ViewModels;

public class IconGlyph
{
    public required string Glyph { get; init; }
    public required string Identifier { get; init; }
    public required string XamlIdentifier { get; init; }
    public required string FontFamily { get; init; }
}

public class IconsViewModel
{
    public ObservableCollection<IconGlyph> Icons { get; } = new();

    public IconsViewModel(string? fontClass = null)
    {
        var asm = typeof(FontAwesome).Assembly;
        foreach (var cfg in IconFontConfigs.All)
        {
            if (fontClass is not null && !string.Equals(cfg.ClassName, fontClass, StringComparison.Ordinal))
                continue;

            // Find the generated static class that matches the configured class name exactly
            var type = asm.GetTypes()
                .FirstOrDefault(t => t.IsAbstract && t.IsSealed
                    && t.Namespace == cfg.Namespace
                    && t.Name == cfg.ClassName);

            if (type is not null)
            {
                AddIcons(type, cfg.FontAlias, type.Name);
            }
        }
    }

    private static readonly HashSet<string> SkipFields = new() { "FontFamily" };

    private void AddIcons(Type type, string fontFamily, string identifierPrefix)
    {
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
        foreach (var field in fields)
        {
            if (field.FieldType != typeof(string)) continue;
            if (SkipFields.Contains(field.Name)) continue;
            var glyph = field.GetValue(null) as string;
            if (string.IsNullOrEmpty(glyph)) continue;
            Icons.Add(new IconGlyph
            {
                Glyph = glyph!,
                FontFamily = fontFamily,
                Identifier = $"{identifierPrefix}.{field.Name}",
                XamlIdentifier = $"icons:{identifierPrefix}.{field.Name}"
            });
        }
    }
}
