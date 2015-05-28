namespace Core.Web.Infrastructure
{
    public enum ESaveResult
    {
        NoAffectedRows,
        Success,
        ConcurrencyError,
        Error
    }
}