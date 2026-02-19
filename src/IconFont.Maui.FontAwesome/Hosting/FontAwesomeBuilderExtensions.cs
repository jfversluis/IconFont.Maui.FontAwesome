using Microsoft.Maui.Hosting;

namespace IconFont.Maui.FontAwesome;

public static partial class IconFontBuilderExtensions
{
    /// <summary>
    /// Registers all Font Awesome font styles (Solid, Regular, Brands).
    /// </summary>
    public static MauiAppBuilder UseFontAwesome(this MauiAppBuilder builder)
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

    // Called by generated per-font helpers (UseFontAwesomeSolid, etc.)
    internal static MauiAppBuilder UseIconFont(this MauiAppBuilder builder, string fontClass)
    {
        var cfg = System.Array.Find(IconFontConfigs.All, x => x.ClassName == fontClass);
        if (cfg is not null)
        {
            builder.ConfigureFonts(fonts => fonts.AddFont(cfg.FontFile, cfg.FontAlias));
        }
        return builder;
    }

    // Kept for backwards compatibility with generated UseIconFonts() alias
    internal static MauiAppBuilder UseIconFont(this MauiAppBuilder builder) => builder.UseFontAwesome();
}
