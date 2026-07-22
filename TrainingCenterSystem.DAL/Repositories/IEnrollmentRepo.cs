using Microsoft.EntityFrameworkCore;
using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL
{
    public class EnrollmentRepo:IEnrollmentRepo
    {
        private readonly TrainingCenterDbContext _context;

        public EnrollmentRepo(TrainingCenterDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Enrollment>> GetAllEnrollments()
        {
            return await _context.Enrollments.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsByStudentId(int studentId)
        {
            return await _context.Enrollments.AsNoTracking()
                .Where(e => e.StudentID == studentId).ToListAsync();
        }
        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsByCourseId(int courseId)
        {
            return await _context.Enrollments.AsNoTracking()
                .Where(e => e.CourseID == courseId).ToListAsync();
        }


        public async Task<Enrollment?> GetEnrollmentById(int id)
        {
            return await _context.Enrollments.AsNoTracking().SingleOrDefaultAsync(E => E.EnrollmentID == id);
        }
        public async Task<bool> CreateEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);

            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);

            return await _context.SaveChangesAsync() > 0;
        }

    }
}
