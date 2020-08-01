using System.Data;
using Npgsql;

namespace repository_dapper.Data
{
    public class PostgresProvider : IDbProvider
    {
        public IDbConnection GetDbConnection(string connectionString) 
            => new NpgsqlConnection(connectionString);
    }
}