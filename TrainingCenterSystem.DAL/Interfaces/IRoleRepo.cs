using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL
{
    public interface IRoleRepo
    {
         Task<IEnumerable<Role>> GetAllRolesAsync();
         Task<Role?> GetRoleByIdAsync(int id);
         Task<Role?> CreateRoleAsync(Role role);
         Task<Role?> UpdateRoleAsync(Role role);
        bool IsRoleExist(int id);
        bool IsRoleExist(string RoleName);
    }
}
