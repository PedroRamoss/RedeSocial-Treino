using Dapper;
using RedeSocial.Database.Configuration;
using RedeSocial.Domain.Entities;
using RedeSocial.Domain.Interfaces.Repositories;

namespace RedeSocial.Database.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DatabaseConnection _connection;

        public PostRepository(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task DeleteAPostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task EditAPostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public async Task MakeAPostAsync(Post post)
        {
            var conenction = _connection.GetConnection();
            var sql = @"INSERT INTO POSTS(Id, UserId, Content, PhotoUrl, CreatedAt) VALUES (@Id, @UserId, @Content, @PhotoUrl, @CreatedAt)";

            var result = await conenction.ExecuteAsync(sql,
                 new
                 {
                     @id = post.Id,
                     @Userid = post.User.Id,
                     @Content = post.Content,
                     @PhotoUrl = post.PhotoUrl,
                     @CreatedAt = post.CreatedAt
                 });
        }
    }
}
