using Airespring.Demo.Models;

namespace Airespring.Demo.Interfaces
{
    public interface IEmployeeProvider
    {
        Task<IEnumerable<Employee>> GetEmployees(CancellationToken cancellationToken);
        Task<Employee> GetEmployee(Guid id, CancellationToken cancellationToken);
        Task InsertEmployee(Employee employee, CancellationToken cancellationToken);
        Task UpdateEmployee(Employee employee, CancellationToken cancellationToken);
        Task DeleteEmployee(Guid id, CancellationToken cancellationToken);
    }
}
