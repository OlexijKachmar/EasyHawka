using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HawksStartApp.Models.Repositories
{
    public class BaseRepository<T> : IGenericRepository<T> where T : class
    {
        protected HawkaContext hawkaContext;
        protected DbSet<T> dbSet;

        public BaseRepository(HawkaContext hawkaContext)
        {
            this.hawkaContext = hawkaContext;
            this.dbSet = hawkaContext.Set<T>();
        }

        public virtual void Create(T item)
        {
            this.dbSet.Add(item);
            this.hawkaContext.SaveChanges();
        }

        public void Clear()
        {
            this.dbSet.RemoveRange(this.dbSet);
        }

    }
}