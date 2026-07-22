using TrainingCenterSystem.Entities;

namespace TrainingCenterSystem.DAL
{
    public interface IStudentRepo
    {
         Task<IEnumerable<Student>> GetAll();
         Task<Student?> GetStudentById(int id);
         Task<bool> CreateStudent(Student student);
         Task<bool> UpdateStudent(Student student);
         Task<bool> DeleteStudent(int id);
    }
}
