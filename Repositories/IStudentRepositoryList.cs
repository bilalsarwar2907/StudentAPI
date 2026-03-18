using StudentAPI.Models;

namespace StudentAPI.Repositories
{
    public interface IStudentRepositoryList
    {
        Student? Add(Student student);
        Student? Delete(int id);
        IEnumerable<Student> GetAll();
        Student? GetById(int? id);
        Student? Update(int? id, Student student);

        IEnumerable<Student> GetAll(int? birthYearAfter, int? birthYearBefore, string? sortBy);
    }
}