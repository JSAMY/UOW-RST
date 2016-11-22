using Restaurant.Core;
using Restaurant.DatabaseContext;
using Restaurant.Interface.Repository;
using System;
using System.Data.Entity;

namespace Restaurant.DAL
{
    public class Repository<T>  : IRepository<T> where T:Entity
    {
        private readonly ApplicationDbContext context;
        private IDbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Save(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.Entities.Add(entity);
            this.context.SaveChanges();

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
