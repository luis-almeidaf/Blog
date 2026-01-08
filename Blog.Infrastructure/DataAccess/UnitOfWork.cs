using Blog.Domain.Repositories;

namespace Blog.Infrastructure.DataAccess;

public class UnitOfWork(BlogDbContext dbContext) : IUnitOfWork
{
    public Task CommitAsync() => dbContext.SaveChangesAsync();
}