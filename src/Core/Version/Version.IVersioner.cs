namespace Dondoko;

public static partial class Version
{
    public interface IVersioner
    {
        public string GameVersion { get; }

        public int InternalGameVersion { get; }
    }
}