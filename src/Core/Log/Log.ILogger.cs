namespace Dondoko;

public static partial class Log
{
    public interface ILogger
    {
        public void Log(LogLevel level, object? message);
    }
}