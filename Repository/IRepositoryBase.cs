using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace repository_dapper.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> FindAllAsync();
        Task<TEntity> FindByIdAsync(Guid id);
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
    }
}