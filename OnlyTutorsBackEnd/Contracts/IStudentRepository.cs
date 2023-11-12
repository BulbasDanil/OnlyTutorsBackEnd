using OnlyTutorsBackEnd.Models;

namespace OnlyTutorsBackEnd.Contracts
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<Student>> GetStudents();
        public Task<IEnumerable<Student>> GetStudentsByLesson(int lessonId);
        public Task<int> InsertStudent(Student student);
        public Task<int> UpdateStudent(Student student, int studentid);


    }
}
