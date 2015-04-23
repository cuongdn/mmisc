namespace Core.Business.ObjectFactories
{
    public abstract class ObjectFactoryBase<T, TE>
    {
        public T ModelObject { get; set; }
        public TE DbEntity { get; set; }

        public abstract void Fetch();
        public abstract void Get(object id);
    }
}