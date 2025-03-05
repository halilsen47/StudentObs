using DataAccess.Context;
using DataAccess.Repository.Abstractions;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Concrate
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        private readonly AppDbContext context;

        public RepositoryBase(AppDbContext context)
        {
            this.context = context;
        }

        public  void Add(T Entity)
        {
            if (Entity != null)
            {
                context.Set<T>().Add(Entity);   
            }
        }

       
        public void Delete(T Entity)
        {
            if(Entity != null)
            {
                context.Set<T>().Remove(Entity);
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            query = query.Where(predicate);

            if (includeProperties.Any())
            {
                foreach(var property in includeProperties)
                {
                   query = query.Include(property);
                }
            }
            
            return await query.SingleOrDefaultAsync();
        }

        public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            if(predicate != null)
                query = query.Where(predicate);

            if (includeProperties.Any())    
            {
                foreach(var properties in includeProperties)
                {
                    query = query.Include(properties);
                }
            }

            return await query.ToListAsync();

        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);   
        }

        public void Update(T Entity)
        {
            if(Entity != null)
            {
                context.Set<T>().Update(Entity);
            }
        }
    }
}
