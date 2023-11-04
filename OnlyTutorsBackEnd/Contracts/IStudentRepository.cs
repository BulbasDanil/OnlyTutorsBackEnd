using OnlyTutorsBackEnd.Models;

namespace OnlyTutorsBackEnd.Contracts
{
    public interface IStudentRepository : IUserRepository
    {
        public Task<IEnumerable<Student>> GetStudents();

    }
}
