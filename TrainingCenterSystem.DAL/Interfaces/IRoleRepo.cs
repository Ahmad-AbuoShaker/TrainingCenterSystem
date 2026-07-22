using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL
{
    public interface IRoleRepo
    {
         Task<IEnumerable<Role>> GetAll();
         Task<Role?> GetRoleById(int id);
         Task<Role?> CreateRole(Role role);
         Task<Role?> UpdateRole(Role role);
        Task<bool> IsRoleExist(int id);
        Task<bool> IsRoleExist (string RoleName);
    }
}
