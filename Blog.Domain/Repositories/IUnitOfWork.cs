namespace Blog.Domain.Repositories;

public interface IUnitOfWork
{
    Task CommitAsync();
}