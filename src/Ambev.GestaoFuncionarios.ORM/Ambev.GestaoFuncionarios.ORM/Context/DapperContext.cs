using Npgsql;
using System.Data;

namespace Ambev.GestaoFuncionarios.ORM.Context
{
    public class DapperContext
    {
        private readonly string? _connectionString;
        public IDbConnection Connection;

        public DapperContext(string? connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
