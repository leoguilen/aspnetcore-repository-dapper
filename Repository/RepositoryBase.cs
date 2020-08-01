using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using repository_dapper.Data;
using repository_dapper.Options;

namespace repository_dapper.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected IDbConnection DbConnection { get; private set; }    
        private readonly DatabaseOptions _dbOptions;

        public RepositoryBase(DatabaseOptions dbOptions)
        {
            _dbOptions = dbOptions;
            DbConnection = new DbContext()
                .SetDbProvider(_dbOptions.ProviderName)
                .GetDbContext(_dbOptions.ConnectionString);
        }

        public async Task<IQueryable<TEntity>> FindAllAsync()
        {
            DbConnection.Open();
            
            try 
            { 
                var results = await DbConnection
                    .GetAllAsync<TEntity>(); 

                return results
                    .AsQueryable();
            } 
            finally { DbConnection.Close(); }
        }

        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            DbConnection.Open();

            try
            {
                return await DbConnection
                    .GetAsync<TEntity>(id);
            }
            finally { DbConnection.Close(); }
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            DbConnection.Open();
            
            try 
            {
                var inserted = await DbConnection
                .InsertAsync<TEntity>(entity);
            
                return inserted == 0;
            }
            finally { DbConnection.Close(); }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            DbConnection.Open();

            try 
            {
                return await DbConnection
                    .UpdateAsync<TEntity>(entity);
            }
            finally { DbConnection.Close(); }
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            DbConnection.Open();

            try 
            {
                return await DbConnection
                    .DeleteAsync<TEntity>(entity);
            }
            finally { DbConnection.Close(); }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            DbConnection.Open();

            try
            {
                var entity = await DbConnection
                    .GetAsync<TEntity>(id);

                if(entity == null) 
                    return false;

                return await DbConnection
                    .DeleteAsync<TEntity>(entity);
            }
            finally { DbConnection.Close(); }
        }
    }
}