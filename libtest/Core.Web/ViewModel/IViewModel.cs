namespace Core.Web.ViewModel
{
    public interface IViewModel<T>
    {
        T ModelObject { get; set; }
        bool Found { get; }
    }
}