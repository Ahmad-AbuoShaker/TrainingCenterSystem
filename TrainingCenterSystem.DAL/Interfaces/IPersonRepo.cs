using TrainingCenterSystem.Entities;

namespace TrainingCenterSystem.DAL
{
    public interface IPersonRepo
    {
         Task<IEnumerable<Person>> GetAll();
         Task<Person?> GetPersonById(int id);
         Task<bool> CreatePerson(Person person);
         Task<bool> UpdatePerson(Person person);
         Task<bool> DeletePerson(int id);

        Task<bool> IsPhoneNumberExist(string phoneNumber);

    }
}
