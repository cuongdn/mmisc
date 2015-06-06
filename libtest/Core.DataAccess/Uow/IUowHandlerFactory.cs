namespace Core.DataAccess.Uow
{
    public interface IUowHandlerFactory
    {
        IUnitOfWork Create(string key);
    }
}