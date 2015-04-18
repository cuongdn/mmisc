namespace Core.Business.Mapper
{
    public class EntityValueInjection : ExcludeValueInjection
    {
        public EntityValueInjection(bool siteEntity)
        {
            Exclude = siteEntity ? new[] { "Id", "CreatedDate", "UpdatedDate" } : new[] { "Id" };
        }
    }
}