namespace Dondoko;

public static partial class Version
{
    private const string DondokoVersionString = "2022.12.13";
    private const int DefaultInternalGameVersion = 0;

    private static IVersioner? s_versioner;

    static Version() => s_versioner = null;

    public static string DondokoVersion => DondokoVersionString;

    public static string GameVersion
    {
        get
        {
            if (s_versioner is null)
            {
                return string.Empty;
            }

            return s_versioner.GameVersion;
        }
    }

    public static int InternalGameVersion
    {
        get
        {
            if (s_versioner is null)
            {
                return DefaultInternalGameVersion;
            }

            return s_versioner.InternalGameVersion;
        }
    }

    public static void SetVersioner(IVersioner? versioner) => s_versioner = versioner;
}