using Microsoft.EntityFrameworkCore;
using TrainingCenterSystem.Entities;
using System.Collections.Generic;

namespace TrainingCenterSystem.DAL
{
    public class StudentRepo : IStudentRepo
    {
        private readonly TrainingCenterDbContext _context;

        public StudentRepo(TrainingCenterDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.AsNoTracking().ToListAsync();
        }
        public async Task<Student?> GetStudentById(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(s=>s.PersonID == id);
        }
        public async Task<bool> CreateStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            return await _context.SaveChangesAsync() > 0;
            
        }
        public async Task<bool> UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteStudent(int id)
        {
           var rowsAffected = await _context.Students.Where(s => s.PersonID == id)
                   .ExecuteUpdateAsync(setters => setters
                .SetProperty(s => s.IsDeleted , true));

            return rowsAffected > 0 ;
        }
    }
}
