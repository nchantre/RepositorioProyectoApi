using Microsoft.Data.SqlClient;
using System.Data;

namespace Inventario.Infraestructura.BD
{

    public class DBContext 
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public DBContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public int Commit()
        {
            try
            {
                _transaction.Commit();
                return 1;
            }
            catch
            {
                _transaction.Rollback();
                return 0;
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = _connection.BeginTransaction();
            }
        }
        public void Dispose()
        {
            _transaction?.Commit();
            _connection?.Close();
        }
    }


}
