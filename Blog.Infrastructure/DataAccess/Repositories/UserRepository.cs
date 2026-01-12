using Blog.Domain.Entities;
using Blog.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.DataAccess.Repositories;

public class UserRepository(BlogDbContext dbContext) : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    public async Task Add(User user) => await dbContext.Users.AddAsync(user);

    public Task<User?> GetUserByEmail(string email) =>
        dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
}