using My_Angular.Models.Domain;

namespace My_Angular.Infrastructure.Infrastructure
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateAsync(Employee employee);

        Task<Employee> GetByIdAsync(int id);

        Task<IEnumerable<Employee>> GetAllAsync();

        Task UpdateAsync (Employee employee);

        Task DeleteAsync (int id);




    }
}
