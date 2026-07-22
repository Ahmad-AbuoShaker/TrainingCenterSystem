using Microsoft.EntityFrameworkCore;
using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL
{
    
    public class RoleRepo : IRoleRepo
    {
        private readonly TrainingCenterDbContext _context;

        public RoleRepo(TrainingCenterDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _context.Roles.AsNoTracking().ToListAsync();
        }
        public async Task<Role?> GetRoleById(int id)
        {
            return await _context.Roles.AsNoTracking().FirstOrDefaultAsync(r => r.RoleID == id);
        }
        public async Task<Role?> CreateRole(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }
        public async Task<Role?> UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }
        public async Task<bool> IsRoleExist(int id)
        {
            return await _context.Roles.AnyAsync(r => r.RoleID == id);
        }
        public async Task<bool> IsRoleExist(string RoleName)
        {
            return await _context.Roles.AnyAsync(r => r.RoleName == RoleName);
        }
    }
}
