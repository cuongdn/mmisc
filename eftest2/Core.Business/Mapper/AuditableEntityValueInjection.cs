namespace Core.Business.Mapper
{
    public class AuditableEntityValueInjection : ExcludeValueInjection
    {
        public AuditableEntityValueInjection(bool siteEntity)
        {
            Exclude = siteEntity ? new[] { "Id", "CreatedDate", "UpdatedDate" } : new[] { "Id" };
        }
    }
}