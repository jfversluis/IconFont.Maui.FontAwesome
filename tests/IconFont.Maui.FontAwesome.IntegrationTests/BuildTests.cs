using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

namespace IconFont.Maui.FontAwesome.IntegrationTests;

public class BuildTests
{
    [Fact]
    public void Generates_Config_Files_On_Build()
    {
        if (!IsMac()) return;

        var repoRoot = GetRepoRoot();
        var proj = Path.Combine(repoRoot, "src", "IconFont.Maui.FontAwesome", "IconFont.Maui.FontAwesome.csproj");
        var psi = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = "build \"" + proj + "\" -f net10.0-maccatalyst -v minimal",
            WorkingDirectory = repoRoot,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
        var proc = Process.Start(psi)!;
        var output = proc.StandardOutput.ReadToEnd();
        var err = proc.StandardError.ReadToEnd();
        proc.WaitForExit();
        Assert.True(proc.ExitCode == 0, $"build failed: {output}\n{err}");

        var objRoot = Path.Combine(repoRoot, "src", "IconFont.Maui.FontAwesome", "obj");
        var configs = Directory.EnumerateFiles(objRoot, "IconFontConfig.g.cs", SearchOption.AllDirectories).ToList();
        var extensions = Directory.EnumerateFiles(objRoot, "IconFontExtensions.g.cs", SearchOption.AllDirectories).ToList();
        Assert.True(configs.Count > 0, "IconFontConfig.g.cs not found");
        Assert.True(extensions.Count > 0, "IconFontExtensions.g.cs not found");

        var configText = configs.Select(File.ReadAllText).First(text => text.Contains("IconFontConfigs"));
        Assert.Contains("FontAwesomeSolid", configText);
        Assert.Contains("FontAwesomeRegular", configText);
        Assert.Contains("FontAwesomeBrands", configText);

        var extText = extensions.Select(File.ReadAllText).First(text => text.Contains("IconFontBuilderExtensions"));
        Assert.Contains("UseFontAwesomeSolid", extText);
        Assert.Contains("UseFontAwesomeRegular", extText);
        Assert.Contains("UseFontAwesomeBrands", extText);
    }

    private static bool IsMac() => OperatingSystem.IsMacOS();

    private static string GetRepoRoot()
    {
        var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (dir != null && !File.Exists(Path.Combine(dir.FullName, "IconFont.Maui.FontAwesome.sln")))
            dir = dir.Parent!;
        return dir?.FullName ?? Directory.GetCurrentDirectory();
    }
}
