using Dapper;
using OnlyTutorsBackEnd.Contracts;
using OnlyTutorsBackEnd.Models;

namespace OnlyTutorsBackEnd.Repositories
{
    public class TutorRepository //: ITutorRepository
    {
        private DapperContext _context;
        private UserRepository _userRepository;

        public TutorRepository(DapperContext context)
        {
            _context = context;
            _userRepository = new UserRepository(context);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<IEnumerable<Tutor>> GetTutors()
        {
            string query = "SELECT * FROM Tutors";

            using (var connection = _context.CreateConnection())
            {
                var tutors = await connection.QueryAsync<Tutor>(query);
                return tutors.ToList();
            }
        }
    }
}
