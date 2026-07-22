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
        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.AsNoTracking().ToListAsync();
        }
        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await _context.Roles.AsNoTracking().FirstOrDefaultAsync(r => r.RoleID == id);
        }
        public async Task<Role?> CreateRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }
        public async Task<Role?> UpdateRoleAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }
        public bool IsRoleExist(int id)
        {
            return _context.Roles.Any(r => r.RoleID == id);
        }
        public bool IsRoleExist(string RoleName)
        {
            return _context.Roles.Any(r => r.RoleName == RoleName);
        }
    }
}
