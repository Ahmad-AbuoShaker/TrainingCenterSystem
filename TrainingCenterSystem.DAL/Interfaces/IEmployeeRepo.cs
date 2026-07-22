using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL
{
    public interface IEmployeeRepo
    {
         Task<IEnumerable<Employee>> GetAllEmployees();
         Task<Employee?> GetEmployeeById(int id);
         Task<bool> CreateEmployee(Employee employee);
         Task<bool> UpdateEmployee(Employee employee);
         Task<bool> DeleteEmployee(int id);
    }
}
