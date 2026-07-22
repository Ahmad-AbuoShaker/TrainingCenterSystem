using Microsoft.EntityFrameworkCore;
using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL
{
    public class CourseRepo: ICourseRepo
    {
        private readonly TrainingCenterDbContext _context;

        public CourseRepo(TrainingCenterDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.Courses.AsNoTracking().ToListAsync();
        }
       public async Task<IEnumerable<Course>> GetAllCoursesByInstructorId(int instructorId)
        {
            return await _context.Courses.AsNoTracking().Where(c => c.InstructorID == instructorId).ToListAsync();
        }
        public async Task<Course?> GetCourseById(int id)
        {
            return await _context.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.CourseID == id);
        }
        public async Task<bool> CreateCourse(Course course)
        {
            await _context.Courses.AddAsync(course);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteCourse(int id)
        {
            var rowEffected = await _context.Courses.Where(c => c.CourseID == id)
                .ExecuteUpdateAsync(C => C.SetProperty(c => c.IsDeleted, true));

            return rowEffected > 0; 
        }
    }
}
