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

        public async Task<IEnumerable<User>> GetAllUsersAsync()
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
        public async Task<bool> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }
        public bool IsUserNameExist(string UserName)
        {
            return  _context.Users.Any(u => u.UserName == UserName);
        }
        public bool IsEmailExists(string email)
        {
            return  _context.Users.Any(u => u.Email == email);
        }
        public   bool IsUserExist(int id)
        {
            return  _context.Users.Any(u => u.UserID == id);
        }

        public bool IsValidToUpdate(int userId, string email, string userName)
        {
            return _context.Users.Any(u => u.UserID != userId &&
                         (u.Email == email || u.UserName == userName));
        }
        public bool IsValidToCreate(string email, string userName)
        {
            return _context.Users.Any(u => u.Email == email || u.UserName == userName);
        }

    }
}
