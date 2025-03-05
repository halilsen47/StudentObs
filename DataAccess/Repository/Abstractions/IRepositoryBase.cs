using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Abstractions
{
    public interface IRepositoryBase<T> where T : class , new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T,bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
