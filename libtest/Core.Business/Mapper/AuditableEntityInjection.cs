namespace Core.Business.Mapper
{
    public class AuditableEntityInjection : ExcludeValueInjection
    {
        public AuditableEntityInjection(bool siteEntity)
        {
            Exclude = siteEntity ? new[] { "Id", "CreatedDate", "UpdatedDate" } : new[] { "Id" };
        }
    }
}