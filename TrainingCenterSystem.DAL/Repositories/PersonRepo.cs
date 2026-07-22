using Microsoft.EntityFrameworkCore;
using TrainingCenterSystem.Entities;

namespace TrainingCenterSystem.DAL
{
    public class PersonRepo : IPersonRepo
    {
        private readonly TrainingCenterDbContext _context;

        public PersonRepo(TrainingCenterDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _context.People.AsNoTracking().ToListAsync();
        }
        public async Task<Person?> GetPersonById(int id)
        {
            return await _context.People.AsNoTracking().FirstOrDefaultAsync(p => p.PersonID == id);
        }
        public async Task<bool> CreatePerson(Person person)
        {
            await _context.People.AddAsync(person);
            
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdatePerson(Person person)
        {
            _context.People.Update(person);
            return await _context.SaveChangesAsync() > 0; ;
        }
        public async Task<bool> DeletePerson(int id)
        {
            var rowsAffected = await _context.People.Where(s => s.PersonID == id)
                   .ExecuteUpdateAsync(setters => setters
                .SetProperty(s => s.IsDeleted, true));

            return rowsAffected > 0;
        }
        public async Task<bool> IsPhoneNumberExist(string phoneNumber)
        {
            return await _context.People.AnyAsync(p => p.PhoneNumber == phoneNumber);
        }

    }
}
