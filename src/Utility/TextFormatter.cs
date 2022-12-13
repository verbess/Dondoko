using System;

namespace Dondoko.Utility;

public static partial class TextFormatter
{
    private static IFormatter? s_formatter;

    static TextFormatter() => s_formatter = null;

    public static void SetFormatter(IFormatter? formatter) => s_formatter = formatter;

    public static string Format(string format, object? arg0)
    {
        ArgumentNullException.ThrowIfNull(format);

        return s_formatter?.Format(format, arg0) ?? string.Format(format, arg0);
    }

    public static string Format(string format, object? arg0, object? arg1)
    {
        ArgumentNullException.ThrowIfNull(format);

        return s_formatter?.Format(format, arg0, arg1) ?? string.Format(format, arg0, arg1);
    }

    public static string Format(string format, object? arg0, object? arg1, object? arg2)
    {
        ArgumentNullException.ThrowIfNull(format);

        return s_formatter?.Format(format, arg0, arg1, arg2) ?? string.Format(format, arg0, arg1, arg2);
    }

    public static string Format(string format, params object?[] args)
    {
        ArgumentNullException.ThrowIfNull(format);

        return s_formatter?.Format(format, args) ?? string.Format(format, args);
    }
}