using Restaurant.Core;
using Restaurant.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : Entity;

        bool Commit();
    }
}
