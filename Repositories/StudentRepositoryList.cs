using StudentAPI.Models;
namespace StudentAPI.Repositories
{
    public class StudentRepositoryList : IStudentRepositoryList
    {
        public readonly List<Student> _students = new();
        private int _nextId = 1;


        public StudentRepositoryList(bool includeData = false)
        {
            if (!includeData)
            {
                Add(new Student { Name = "Ali", YearOfBirth = 1970 });
                Add(new Student { Name = "Bob", YearOfBirth = 1980 });
                Add(new Student { Name = "Cop", YearOfBirth = 19900 });

            }

        }
        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student? GetById(int? id)
        {

            return _students.FirstOrDefault(s => s.Id == id);
        }

        public Student? Add(Student student)
        {
            if (student == null)
                return null;
            student.Id = _nextId++;
            _students.Add(student);
            return student;
        }

        public Student? Update(int? id, Student student)

        {
            var studentToUpdate = GetById(id);
            if (studentToUpdate == null)
                return null;
            studentToUpdate.Name = student.Name;
            studentToUpdate.YearOfBirth = student.YearOfBirth;
            return studentToUpdate;
        }

        public Student? Delete(int id)
        {
            var studentToDelete = GetById(id);
            if (studentToDelete == null)
                return null;
            _students.Remove(studentToDelete);
            return studentToDelete;
        }

        public IEnumerable<Student> GetAll(int? birthYearAfter, int? birthYearBefore, string? sortBy)
        {
            var result = _students.AsEnumerable();

            //filtering
            if (birthYearAfter .HasValue)
                result = result.Where(s=>s.YearOfBirth >= birthYearAfter.Value);

            if (birthYearBefore .HasValue)
                result = result.Where(s=>s.YearOfBirth <= birthYearBefore.Value);

            //Sorting
            result = sortBy switch
            {
                "id" => result.OrderBy(s => s.Id),
                "id desc" => result.OrderByDescending(s => s.Id),
                "name desc" => result.OrderByDescending(s => s.Name),
                "name" => result.OrderBy(s => s.Name),
                "birthYear desc" => result.OrderByDescending(s => s.YearOfBirth),
                "birthYear" => result.OrderBy(s => s.YearOfBirth),

                _ => result


            };
            return result.ToList();
        }
    }
}
