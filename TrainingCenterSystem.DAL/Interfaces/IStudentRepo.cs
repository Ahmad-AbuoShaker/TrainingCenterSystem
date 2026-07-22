using TrainingCenterSystem.Entities;

namespace TrainingCenterSystem.DAL.Interfaces
{
    public interface IStudentRepo
    {
         Task<IEnumerable<Student>> GetAllStudentsAsync();
         Task<Student?> GetStudentByIdAsync(int id);
         Task<Student?> CreateStudentAsync(Student student);
         Task<Student?> UpdateStudentAsync(Student student);
         Task<Student?> DeleteStudentAsync(int id);
    }
}
