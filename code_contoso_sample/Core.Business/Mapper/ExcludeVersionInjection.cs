namespace Core.Business.Mapper
{
    public class ExcludeVersionInjection : ExcludeValueInjection
    {
        public ExcludeVersionInjection()
        {
            Exclude = new[] { "RowVersion" };
        }
    }
}