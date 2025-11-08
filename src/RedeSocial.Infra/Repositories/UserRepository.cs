using Dapper;
using RedeSocial.Database.Configuration;
using RedeSocial.Domain.Entities;
using RedeSocial.Domain.Interfaces.DomainServices;
using RedeSocial.Domain.Interfaces.Repositories;
using RedeSocial.Domain.Models;

namespace RedeSocial.Database.Repositories
{
    public class UserRepository : IUserRepository, IUserUniquenessChecker
    {
        private readonly DatabaseConnection _connection;

        public UserRepository(DatabaseConnection connection)
        {
            _connection = connection;
        }

        //Pode ser colocado mais coisas nessa verificação.
        public async Task<bool> IsUniqueAsync(string username)
        {
            using var conn = _connection.GetConnection();

            var sql = @"SELECT 1 FROM Users WHERE Username = @Username LIMIT 1;";

            var retorno = await conn.QueryFirstOrDefaultAsync<int?>(sql, new { Username = username });

            return retorno.HasValue;
        }

        public async Task CreateAsync(User user)
        {
            using var conn = _connection.GetConnection();

            var sql = @"INSERT INTO Users (Id, UserName, Email, PasswordHash, DisplayName, DateOfBirth) 
                        VALUES (@Id, @UserName, @Email, @PasswordHash, @DisplayName, @DateOfBirth)";

            await conn.ExecuteAsync(sql, new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.PasswordHash,
                user.DisplayName,
                user.DateOfBirth
            });
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            using var conn = _connection.GetConnection();

            var sql = "SELECT * FROM Users WHERE UserName = @UserName";

            var user = await conn.QueryFirstOrDefaultAsync<User>(sql, new { @UserName = username });

            return user;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            using var conn = _connection.GetConnection();

            var sql = "SELECT * FROM Users WHERE Id = @Id";

            var user = await conn.QueryFirstOrDefaultAsync<User>(sql, new { @Id = id });

            return user;
        }

        public async Task<bool> UpdateUserAsync(Guid id, UserUpdate user)
        {
            using var conn = _connection.GetConnection();

            var updates = new List<string>();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            if (!string.IsNullOrEmpty(user.Password))
            {
                updates.Add("PasswordHash = @Password");
                parameters.Add("@Password", user.Password);
            }

            if (!string.IsNullOrEmpty(user.DisplayName))
            {
                updates.Add("DisplayName = @DisplayName");
                parameters.Add("@DisplayName", user.DisplayName);
            }

            if (!string.IsNullOrEmpty(user.ProfilePhotoUrl))
            {
                updates.Add("ProfilePictureUrl = @ProfilePictureUrl");
                parameters.Add("@ProfilePictureUrl", user.ProfilePhotoUrl);
            }

            if (updates.Count == 0) return false;

            var sql = $"UPDATE Users SET {string.Join(", ", updates)} WHERE Id = @Id";

            var result = await conn.ExecuteAsync(sql, parameters);

            return result > 0;
        }
    }
}
