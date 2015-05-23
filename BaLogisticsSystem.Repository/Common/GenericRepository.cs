using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BaLogisticsSystem.Models.Common;

namespace BaLogisticsSystem.Repository.Common
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
         where T : BaseEntity
    {
        public DbContext Entities;
        public IDbSet<T> Dbset;

        protected GenericRepository(DbContext context)
        {
            Entities = context;
            Dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Dbset.AsEnumerable();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = Dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return Dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return Dbset.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            Entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            Entities.SaveChanges();
        }
    }
}