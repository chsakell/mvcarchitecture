using System;

namespace Store.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        StoreEntities Init();
    }
}
