using Microsoft.EntityFrameworkCore;
using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL
{
    public  class UserRepo: IUserRepo
    {
        private readonly TrainingCenterDbContext _context;

        public UserRepo(TrainingCenterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
           return await _context.Users.AsNoTracking().ToListAsync();
        }
        public async Task<User?> GetUser(int id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserID == id);
        }
        public async Task<User?> GetUserByUserName(string UserName)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserName == UserName);
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<bool> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateUser(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> IsUserNameExist(string UserName)
        {
            return await _context.Users.AnyAsync(u => u.UserName == UserName);
        }
        public async Task<bool> IsEmailExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
        public async Task<bool> IsUserExist(int id)
        {
            return await _context.Users.AnyAsync(u => u.UserID == id);
        }

        public async Task<bool> IsValidToUpdate(int userId, string email, string userName)
        {
            return await _context.Users.AnyAsync(u => u.UserID != userId &&
                         (u.Email == email || u.UserName == userName));
        }
        public async Task<bool> IsValidToCreate(string email, string userName)
        {
            return await _context.Users.AnyAsync(u => u.Email == email || u.UserName == userName);
        }

    }
}
