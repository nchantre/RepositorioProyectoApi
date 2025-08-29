using Dapper;
using Inventario.Dominio.Entidades;
using Inventario.Dominio.Repositorio;
using Inventario.Infraestructura.Database;
using System.Data;

namespace Inventario.Infraestructura.Repositorio
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(SQLServerConnection connectionFactory)
        {
            _connection = connectionFactory.CreateConnection();
        }

        public async Task<bool> Save(User request)
        {
            string sqlCommand = @"
                INSERT INTO Mst_Users 
                    (employeeNumber, name, AP, AM, userName, accessKey, position, department)
                VALUES
                    (@EmployeeNumber, @Name, @AP, @AM, @UserName, @AccessKey, @Position, @Department)";

            var result = await _connection.ExecuteAsync(sqlCommand, request);
            return result > 0;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            string sqlQuery = @"
                SELECT 
                    employeeNumber,
                    name,
                    AP,
                    AM,
                    userName,
                    accessKey,
                    position,
                    department
                FROM Mst_Users";

            var result = await _connection.QueryAsync<User>(sqlQuery);
            return result;
        }

        public async Task<User?> GetById(string employeeNumber)
        {
            string sqlQuery = @"
                SELECT 
                    employeeNumber,
                    name,
                    AP,
                    AM,
                    userName,
                    accessKey,
                    position,
                    department
                FROM Mst_Users
                WHERE employeeNumber = @employeeNumber";

            return await _connection.QueryFirstOrDefaultAsync<User>(sqlQuery, new { employeeNumber });
        }

        public async Task<bool> Update(User request)
        {
            string sql = @"
                UPDATE Mst_Users
                SET 
                    name = @Name,
                    AP = @AP,
                    AM = @AM,
                    userName = @UserName,
                    accessKey = @AccessKey,
                    position = @Position,
                    department = @Department
                WHERE employeeNumber = @EmployeeNumber";

            int rowsAffected = await _connection.ExecuteAsync(sql, request);
            return rowsAffected > 0;
        }

        public async Task<bool> Delete(string employeeNumber)
        {
            string sql = "DELETE FROM Mst_Users WHERE employeeNumber = @employeeNumber";
            int rowsAffected = await _connection.ExecuteAsync(sql, new { employeeNumber });
            return rowsAffected > 0;
        }
    }
}

