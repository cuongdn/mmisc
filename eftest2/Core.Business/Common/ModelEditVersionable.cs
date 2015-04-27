namespace Core.Business.Common
{
    public abstract class ModelEditVersionable : ModelEditBase
    {
        public byte[] RowVersion { get; set; }
    }
}