using System.Data;

namespace repository_dapper.Data
{
    public interface IDbProvider
    {
        IDbConnection GetDbConnection(string connectionString);
    }
}