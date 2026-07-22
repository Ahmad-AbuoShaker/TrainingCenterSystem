using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL.Interfaces
{
    public interface ICourseRepo
    {
        public Task<IEnumerable<Course>> GetAllCoursesAsync();
        public Task<Course> GetCourseByIdAsync(int id);
        public Task<Course> CreateCourseAsync(Course course);
        public Task<Course> UpdateCourseAsync(Course course);
        public Task<Course> DeleteCourseAsync(int id);

    }
}
