using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL
{
    public interface IEnrollmentRepo
    {
         Task<IEnumerable<Enrollment>> GetAllEnrollments();
        Task<IEnumerable<Enrollment>> GetAllEnrollmentsByStudentId(int studentId);
        Task<IEnumerable<Enrollment>> GetAllEnrollmentsByCourseId(int courseId);
         Task<Enrollment?> GetEnrollmentById(int id);
         Task<bool> CreateEnrollment(Enrollment enrollment);
         Task<bool> UpdateEnrollment(Enrollment enrollment);
      
    }
}
