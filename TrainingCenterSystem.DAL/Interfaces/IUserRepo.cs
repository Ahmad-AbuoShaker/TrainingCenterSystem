using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUser(int id);
        Task<User?> GetUserByUserName(string UserName);
        Task<User?> GetUserByEmail(string email);
        Task<bool> AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);

        bool IsUserNameExist(string UserName);
        bool IsEmailExists(string email);

        bool IsUserExist(int id);

        bool IsValidToUpdate(int userId, string email, string userName);
        bool IsValidToCreate(string email, string userName);


    }
}
