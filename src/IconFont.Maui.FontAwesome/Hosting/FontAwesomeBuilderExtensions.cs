using Microsoft.Maui.Hosting;

namespace IconFont.Maui.FontAwesome;

public static partial class IconFontBuilderExtensions
{
    /// <summary>
    /// Registers all Font Awesome font aliases. Useful for project references if you want explicit initialization.
    /// </summary>
    public static MauiAppBuilder UseIconFont(this MauiAppBuilder builder)
    {
        builder.ConfigureFonts(fonts =>
        {
            foreach (var cfg in IconFontConfigs.All)
            {
                fonts.AddFont(cfg.FontFile, cfg.FontAlias);
            }
        });
        return builder;
    }

    public static MauiAppBuilder UseIconFont(this MauiAppBuilder builder, string fontClass)
    {
        var cfg = System.Array.Find(IconFontConfigs.All, x => x.ClassName == fontClass);
        if (cfg is not null)
        {
            builder.ConfigureFonts(fonts => fonts.AddFont(cfg.FontFile, cfg.FontAlias));
        }
        return builder;
    }
}
