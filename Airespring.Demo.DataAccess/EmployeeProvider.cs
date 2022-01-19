using Airespring.Demo.Interfaces;
using Airespring.Demo.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Airespring.Demo.DataAccess
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly DatabaseConfig databaseConfig;

        public EmployeeProvider(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task DeleteEmployee(Guid id, CancellationToken cancellationToken)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            await connection.ExecuteAsync(new CommandDefinition(@"DELETE FROM Employee WHERE Id = @Id", 
                                                                new { Id = id }, 
                                                                cancellationToken: cancellationToken));
        }

        public async Task<Employee> GetEmployee(Guid id, CancellationToken cancellationToken)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            return await connection.QueryFirstAsync<Employee>(new CommandDefinition("SELECT ID, LastName, FirstName, Phone, Zip, HireDate FROM Employee WHERE id=@id",
                                                                                    new { id = id.ToString() },
                                                                                    cancellationToken: cancellationToken));
        }

        public async Task<IEnumerable<Employee>> GetEmployees(CancellationToken cancellationToken)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            return await connection.QueryAsync<Employee>(
                new CommandDefinition("SELECT ID, LastName, FirstName, Phone, Zip, HireDate FROM Employee order by HireDate asc;",
                                      cancellationToken: cancellationToken));
        }

        public async Task InsertEmployee(Employee employee, CancellationToken cancellationToken)
        {
            employee.ID = Guid.NewGuid().ToString();

            using var connection = new SqliteConnection(databaseConfig.Name);

            await connection.ExecuteAsync(new CommandDefinition("INSERT INTO Employee (ID, LastName, FirstName, Phone, Zip, HireDate)" +
                "VALUES (@ID, @LastName, @FirstName, @Phone, @Zip, @HireDate);", employee,
                                      cancellationToken: cancellationToken));
        }
    

        public Task UpdateEmployee(Employee employee, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
