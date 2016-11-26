using Restaurant.Core;
using Restaurant.DatabaseContext;
using Restaurant.Interface;
using Restaurant.Interface.Repository;
using System;
using System.Collections.Generic;

namespace Restaurant.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext context;
        private bool disposed;
        private Dictionary<string, object> repositories;

        public UnitOfWork(IApplicationDbContext _context)
        {
            this.context = _context;
        }

        //public UnitOfWork()
        //{
        //    context = new ApplicationDbContext();
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public bool Commit()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IRepository<T> Repository<T>() where T : Entity
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)repositories[type];
        }

        private IRepository<T> Repositoryxx<T>() where T : Entity
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)repositories[type];
        }
    }
}
