namespace Core.Web.Infrastructure
{
    public enum ESaveResult
    {
        NotSaved,
        Success,
        Exception,
        DataException,
        ConcurrencyException
    }
}