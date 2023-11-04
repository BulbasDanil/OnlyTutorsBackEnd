using Dapper;
using OnlyTutorsBackEnd.Contracts;
using OnlyTutorsBackEnd.Models;

namespace OnlyTutorsBackEnd.Repositories
{
    public class StudentRepository //: IStudentRepository
    {
        private DapperContext _context;
        private UserRepository _userRepository;

        public StudentRepository(DapperContext context)
        {
            _context = context;
            _userRepository = new UserRepository(context);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            string query = "SELECT * FROM Students";

            using (var connection = _context.CreateConnection())
            {
                var students = await connection.QueryAsync<Student>(query);
                return students.ToList();
            }
        }   
    }
}
