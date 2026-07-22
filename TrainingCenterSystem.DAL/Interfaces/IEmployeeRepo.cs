using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL.Interfaces
{
    public interface IEmployeeRepo
    {
        public Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        public Task<Employee> GetEmployeeByIdAsync(int id);
        public Task<Employee> CreateEmployeeAsync(Employee employee);
        public Task<Employee> UpdateEmployeeAsync(Employee employee);
        public Task<Employee> DeleteEmployeeAsync(int id);
    }
}
