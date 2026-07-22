using TrainingCenterSystem.Entities;


namespace TrainingCenterSystem.DAL
{
    public interface ICourseRepo
    {
         Task<IEnumerable<Course>> GetAllCourses();
         Task<IEnumerable<Course>> GetAllCoursesByInstructorId(int instructorId);
         Task<Course?> GetCourseById(int id);
         Task<bool> CreateCourse(Course course);
         Task<bool> UpdateCourse(Course course);
         Task<bool> DeleteCourse(int id);

    }
}
