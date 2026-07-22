using TrainingCenterSystem.Entities;

namespace TrainingCenterSystem.DAL.Interfaces
{
    public interface IPersonRepo
    {
        public Task<IEnumerable<Person>> GetAllPersonsAsync();
        public Task<Person> GetPersonByIdAsync(int id);
        public Task<Person> CreatePersonAsync(Person person);
        public Task<Person> UpdatePersonAsync(Person person);
        public Task<Person> DeletePersonAsync(int id);


    }
}
