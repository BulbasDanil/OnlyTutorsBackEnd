using OnlyTutorsBackEnd.Models;

namespace OnlyTutorsBackEnd.Contracts
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsers();
      //  public Task<User> GetById(int id);  
        public Task InsertUser(User user);
        public Task UpdateUser(User user, int userid);  
        public Task RemoveUser(int userid);
        public Task<int> ValidateUserLogin(string email, string passwordHash);
    }
}