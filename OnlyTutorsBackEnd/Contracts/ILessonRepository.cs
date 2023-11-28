using OnlyTutorsBackEnd.Models;

namespace OnlyTutorsBackEnd.Contracts
{
    public interface ILessonRepository
    {
        public Task<IEnumerable<Lesson>> GetLessons();
        public Task<IEnumerable<ViewLessson>> SearchForLessons(string searchString);
        public Task<int> InsertLesson (Lesson lesson);
        public Task<int> InsertStudentLessons(int studentid, int lessonid);
        public Task<IEnumerable<Student>> GetAllLessonStudents(int lessonid);
    }
}
