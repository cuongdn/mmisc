using System.Linq;

namespace Core
{
    internal class TypesWithIdDbSet<T> : FakeDbSet<T>
        where T : class,new()
    {
        public override T Find(params object[] keyValues)
        {
            var keyValue = (int)keyValues.FirstOrDefault();
            return this.SingleOrDefault(t => (int)(t.GetType()
                            .GetProperty(t.GetType().Name + "ID")
                            .GetValue(t, null)) == keyValue);
        }
    }
}
