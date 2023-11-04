using OnlyTutorsBackEnd.Models;

namespace OnlyTutorsBackEnd.Contracts
{
    public interface ITutorRepository : IUserRepository
    {
        public Task<IEnumerable<Tutor>> GetTutors();
    }
}
