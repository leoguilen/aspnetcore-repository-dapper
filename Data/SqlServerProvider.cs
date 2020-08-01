using System.Data;
using System.Data.SqlClient;

namespace repository_dapper.Data
{
    public class SqlServerProvider : IDbProvider
    {
        public IDbConnection GetDbConnection(string connectionString) 
            => new SqlConnection(connectionString);
    }
}