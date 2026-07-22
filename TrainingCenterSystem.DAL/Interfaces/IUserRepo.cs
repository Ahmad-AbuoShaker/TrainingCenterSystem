using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetUser(int id);
        Task<User?> GetUserByUserName(string UserName);
        Task<User?> GetUserByEmail(string email);
        Task<bool> AddUser(User user);
        Task<bool> UpdateUser(User user);

        Task<bool> IsUserNameExist(string UserName);
        Task<bool> IsEmailExists(string email);

        Task<bool> IsUserExist(int id);

        Task<bool> IsValidToUpdate(int userId, string email, string userName);
        Task<bool> IsValidToCreate(string email, string userName);


    }
}
