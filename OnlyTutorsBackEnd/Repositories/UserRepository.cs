using Dapper;
using NpgsqlTypes;
using OnlyTutorsBackEnd.Contracts;
using OnlyTutorsBackEnd.Models;
using System.Data;

namespace OnlyTutorsBackEnd.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            string query = "SELECT * FROM Users";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var users = await connection.QueryAsync<User>(query);
                    return users.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return Enumerable.Empty<User>();
            }
        }

        public async Task InsertUser(User user)
        {
            // creating paramethrized query to prevent sql injection
            string query = "INSERT INTO Users (Name, Surname, Email,Password, PhoneNumber, DateOfBirth, Rating) VALUES (@Name, @Surname, @Email, @Password, @PhoneNumber, @DateOfBirth, @Rating)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", user.Name, DbType.String);
            parameters.Add("Surname", user.Surname, DbType.String);
            parameters.Add("Email", user.Email, DbType.String);
            parameters.Add("Password", user.Password, DbType.String);
            parameters.Add("PhoneNumber", user.PhoneNumber, DbType.String);
            parameters.Add("DateOfBirth", user.DateOfBirth, DbType.Date);
            parameters.Add("Rating", user.Rating, DbType.Decimal);

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        public async Task UpdateUser(User user, int userid)
        {
            string query = "UPDATE Users Set " +
                "Name = @Name, Surname = @Surname, Email = @Email, Password = @Password, PhoneNumber = @PhoneNumber, DateOfBirth = @DateOfBirth, Rating = @Rating" +
                "WHERE Id = @userid";
            
            var parameters = new DynamicParameters();
            parameters.Add("Name", user.Name, DbType.String);
            parameters.Add("Surname", user.Surname, DbType.String);
            parameters.Add("Email", user.Email, DbType.String);
            parameters.Add("Password", user.Password, DbType.String);
            parameters.Add("PhoneNumber", user.PhoneNumber, DbType.String);
            parameters.Add("DateOfBirth", user.DateOfBirth, DbType.Date);
            parameters.Add("userid", userid, DbType.Int32);
            parameters.Add("Rating", user.Rating, DbType.Double);

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        public async Task RemoveUser(int userid)
        {
            string query = "DELETE FROM Users WHERE Id = @userid";

            var parameters = new DynamicParameters();
            parameters.Add("userid", userid);

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        // todo: move validate password function to the database functions
        public async Task<int> ValidateUserLogin(string email, string passwordHash)
        {
            string query = "SELECT Password FROM Users WHERE email = @email";

            var parameters = new DynamicParameters();
            parameters.Add("email", email);

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    User user = (await connection.QueryAsync<User>(query, parameters)).First();

                    if (user.Password == passwordHash)
                        return user.Id;
                    else
                        return -1;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
