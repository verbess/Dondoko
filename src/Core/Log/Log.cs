using Dondoko.Utility;

namespace Dondoko;

public static partial class Log
{
    private static ILogger? s_logger;

    static Log() => s_logger = null;

    public static void SetLogger(ILogger? logger) => s_logger = logger;

    #region Debug level

    public static void Debug(object? message) => s_logger?.Log(LogLevel.Debug, message);

    public static void Debug(string? message) => s_logger?.Log(LogLevel.Debug, message);

    public static void Debug(string format, object? arg0) => s_logger?.Log(LogLevel.Debug, TextFormatter.Format(format, arg0));

    public static void Debug(string format, object? arg0, object? arg1) => s_logger?.Log(LogLevel.Debug, TextFormatter.Format(format, arg0, arg1));

    public static void Debug(string format, object? arg0, object? arg1, object? arg2) => s_logger?.Log(LogLevel.Debug, TextFormatter.Format(format, arg0, arg1, arg2));

    public static void Debug(string format, params object?[] args) => s_logger?.Log(LogLevel.Debug, TextFormatter.Format(format, args));

    #endregion

    #region Info level

    public static void Info(object? message) => s_logger?.Log(LogLevel.Info, message);

    public static void Info(string? message) => s_logger?.Log(LogLevel.Info, message);

    public static void Info(string format, object? arg0) => s_logger?.Log(LogLevel.Info, TextFormatter.Format(format, arg0));

    public static void Info(string format, object? arg0, object? arg1) => s_logger?.Log(LogLevel.Info, TextFormatter.Format(format, arg0, arg1));

    public static void Info(string format, object? arg0, object? arg1, object? arg2) => s_logger?.Log(LogLevel.Info, TextFormatter.Format(format, arg0, arg1, arg2));

    public static void Info(string format, params object?[] args) => s_logger?.Log(LogLevel.Info, TextFormatter.Format(format, args));

    #endregion

    #region Warning level

    public static void Warning(object? message) => s_logger?.Log(LogLevel.Warning, message);

    public static void Warning(string? message) => s_logger?.Log(LogLevel.Warning, message);

    public static void Warning(string format, object? arg0) => s_logger?.Log(LogLevel.Warning, TextFormatter.Format(format, arg0));

    public static void Warning(string format, object? arg0, object? arg1) => s_logger?.Log(LogLevel.Warning, TextFormatter.Format(format, arg0, arg1));

    public static void Warning(string format, object? arg0, object? arg1, object? arg2) => s_logger?.Log(LogLevel.Warning, TextFormatter.Format(format, arg0, arg1, arg2));

    public static void Warning(string format, params object?[] args) => s_logger?.Log(LogLevel.Warning, TextFormatter.Format(format, args));

    #endregion

    #region Error level

    public static void Error(object? message) => s_logger?.Log(LogLevel.Error, message);

    public static void Error(string? message) => s_logger?.Log(LogLevel.Error, message);

    public static void Error(string format, object? arg0) => s_logger?.Log(LogLevel.Error, TextFormatter.Format(format, arg0));

    public static void Error(string format, object? arg0, object? arg1) => s_logger?.Log(LogLevel.Error, TextFormatter.Format(format, arg0, arg1));

    public static void Error(string format, object? arg0, object? arg1, object? arg2) => s_logger?.Log(LogLevel.Error, TextFormatter.Format(format, arg0, arg1, arg2));

    public static void Error(string format, params object?[] args) => s_logger?.Log(LogLevel.Error, TextFormatter.Format(format, args));

    #endregion

    #region Fatal level

    public static void Fatal(object? message) => s_logger?.Log(LogLevel.Fatal, message);

    public static void Fatal(string? message) => s_logger?.Log(LogLevel.Fatal, message);

    public static void Fatal(string format, object? arg0) => s_logger?.Log(LogLevel.Fatal, TextFormatter.Format(format, arg0));

    public static void Fatal(string format, object? arg0, object? arg1) => s_logger?.Log(LogLevel.Fatal, TextFormatter.Format(format, arg0, arg1));

    public static void Fatal(string format, object? arg0, object? arg1, object? arg2) => s_logger?.Log(LogLevel.Fatal, TextFormatter.Format(format, arg0, arg1, arg2));

    public static void Fatal(string format, params object?[] args) => s_logger?.Log(LogLevel.Fatal, TextFormatter.Format(format, args));

    #endregion
}