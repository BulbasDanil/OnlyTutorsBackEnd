using OnlyTutorsBackEnd.Models;

namespace OnlyTutorsBackEnd.Contracts
{
    public interface ITutorRepository
    {
        public Task<IEnumerable<Tutor>> GetTutors();
        public Task<Tutor> GetTutorById(int userId);
        public Task<IEnumerable<Tutor>> SearchForTutors(string searchString);
        public Task<int> InsertTutor (Tutor tutor);
        public Task<int> UpdateTutor(Tutor tutor, int userId);
    }
}
