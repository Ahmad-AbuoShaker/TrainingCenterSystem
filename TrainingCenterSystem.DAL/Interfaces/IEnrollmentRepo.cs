using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL.Interfaces
{
    public interface IEnrollmentRepo
    {
        public Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();
        public Task<Enrollment> GetEnrollmentByIdAsync(int id);
        public Task<Enrollment> CreateEnrollmentAsync(Enrollment enrollment);
        public Task<Enrollment> UpdateEnrollmentAsync(Enrollment enrollment);
        public Task<Enrollment> DeleteEnrollmentAsync(int id);
    }
}
