using System.Data;
using MySql.Data.MySqlClient;

namespace repository_dapper.Data
{
    public class MySqlProvider : IDbProvider
    {
        public IDbConnection GetDbConnection(string connectionString)
            => new MySqlConnection(connectionString);
    }
}