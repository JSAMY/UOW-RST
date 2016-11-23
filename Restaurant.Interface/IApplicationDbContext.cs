using Restaurant.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Interface
{
    public interface IApplicationDbContext: IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : Entity;
        int SaveChanges();
    }
}
