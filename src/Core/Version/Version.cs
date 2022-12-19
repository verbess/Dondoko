namespace Dondoko;

public static partial class Version
{
    private const string DondokoVersionString = "2022.12.13";
    private const int DefaultInternalGameVersion = 0;

    private static IVersioner? s_versioner;

    static Version() => s_versioner = null;

    public static string DondokoVersion => DondokoVersionString;

    public static string GameVersion
        => s_versioner?.GameVersion ?? string.Empty;

    public static int InternalGameVersion
        => s_versioner?.InternalGameVersion ?? DefaultInternalGameVersion;

    public static void SetVersioner(IVersioner? versioner)
        => s_versioner = versioner;
}