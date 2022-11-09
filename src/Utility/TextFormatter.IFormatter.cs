namespace Dondoko.Utility
{
    public static partial class TextFormatter
    {
        public interface IFormatter
        {
            public string Format(string format, object? arg0);

            public string Format(string format, object? arg0, object? arg1);

            public string Format(string format, object? arg0, object? arg1, object? arg2);

            public string Format(string format, params object?[] args);
        }
    }
}