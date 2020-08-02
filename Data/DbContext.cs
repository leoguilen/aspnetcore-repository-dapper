using System.Data;

namespace repository_dapper.Data
{
    public class DbContext
    {
        private IDbProvider _dbProvider;

        public DbContext SetDbProvider(string providerType)
        {
            _dbProvider = providerType switch {
                "SQLServer" => _dbProvider = new SqlServerProvider(),
                "MySql" => _dbProvider = new MySqlProvider(),
                _ => null
            };

            return this;
        }

        public IDbConnection GetDbContext(string connectionString) 
            => _dbProvider.GetDbConnection(connectionString);
    }
}