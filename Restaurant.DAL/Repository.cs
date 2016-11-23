using Restaurant.Core;
using Restaurant.DatabaseContext;
using Restaurant.Interface;
using Restaurant.Interface.Repository;
using System;
using System.Data.Entity;

namespace Restaurant.DAL
{
    public class Repository<T>  : IRepository<T> where T:Entity
    {
        private readonly IApplicationDbContext context;
        private IDbSet<T> entities;

        public Repository(IApplicationDbContext _context)
        {
            this.context = _context;
        }

        public bool Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.Entities.Add(entity);
            return true;
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }
    }
}
