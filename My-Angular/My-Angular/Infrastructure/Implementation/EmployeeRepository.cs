using Microsoft.EntityFrameworkCore;
using My_Angular.Data;
using My_Angular.Infrastructure.Infrastructure;
using My_Angular.Models.Domain;

namespace My_Angular.Infrastructure.Implementation
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context) 
        
        {
        _context = context;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            return _context.Employees.FirstAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FirstAsync(x => x.Id == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

            }
        }

    }
}
