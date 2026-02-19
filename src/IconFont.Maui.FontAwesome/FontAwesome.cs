using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls.Internals;

namespace IconFont.Maui.FontAwesome;

/// <summary>
/// Provides helper APIs for the default Font Awesome icon font.
/// Uses the FontFamily from the first configured font (Solid by default).
/// </summary>
[Preserve(AllMembers = true)]
public static class FontAwesome
{
    /// <summary>
    /// The font family alias for the default (Solid) Font Awesome style.
    /// </summary>
    public static string FontFamily => IconFontConfigs.Default.FontAlias;

    /// <summary>
    /// Creates a <see cref="FontImageSource"/> for a Font Awesome glyph.
    /// </summary>
    /// <param name="glyph">The glyph string, typically retrieved from <c>FontAwesomeSolid</c>, <c>FontAwesomeRegular</c>, or <c>FontAwesomeBrands</c>.</param>
    /// <param name="color">Optional foreground color; defaults to <see cref="Colors.Black"/>.</param>
    /// <param name="size">Icon size in device-independent units.</param>
    public static FontImageSource Create(string glyph, Color? color = null, double size = 24d)
    {
        return new FontImageSource
        {
            FontFamily = FontFamily,
            Glyph = glyph,
            Color = color ?? Colors.Black,
            Size = size
        };
    }
}
