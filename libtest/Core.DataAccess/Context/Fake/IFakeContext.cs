using System;
using System.Collections.Generic;

namespace Core.DataAccess.Context.Fake
{
    public interface IFakeContext : IDataContext
    {
        IDictionary<Type, string[]> EntityKeyMembers { get; }
    }
}