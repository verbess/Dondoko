namespace Dondoko;

internal static class SR
{
    #region Dondoko exceptions

    public const string Dondoko_FrameworkException = "Dondoko framework error.";

    #endregion

    #region Invalid operation exceptions

    public const string InvalidOperation_InstanceCreationFailed
        = "Failed to create a instance.";
    public const string InvalidOperation_ReferenceReleased
        = "The reference has already been released.";
    public const string InvalidOperation_TypeMismatch
        = "A mismatch of the generic type with the reference type.";

    #endregion
}