using System.Data;
using Microsoft.Data.SqlClient;

namespace Inventario.Infraestructura.Database
{

    public class SQLServerConnection
    {
        private readonly string _connectionString;

        public SQLServerConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
