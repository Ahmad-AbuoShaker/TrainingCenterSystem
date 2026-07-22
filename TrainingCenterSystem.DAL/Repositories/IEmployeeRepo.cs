using Microsoft.EntityFrameworkCore;
using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly TrainingCenterDbContext _context;

        public EmployeeRepo(TrainingCenterDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.AsNoTracking().ToListAsync();
        }
        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.PersonID == id);
        }
        public async Task<bool> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);

            return await _context.SaveChangesAsync() > 0 ;
        }
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteEmployee(int id)
        {

            var rowsAffected = await _context.Employees.Where(e => e.PersonID == id)
                .ExecuteUpdateAsync(setters => setters
             .SetProperty(e => e.IsDeleted, true));

            return rowsAffected > 0;
        }
    }
}
